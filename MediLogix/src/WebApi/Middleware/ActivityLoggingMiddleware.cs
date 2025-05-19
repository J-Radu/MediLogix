namespace MediLogix.WebApi.Middleware;

public class ActivityLoggingMiddleware(RequestDelegate next, ILogger<ActivityLoggingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context, IActivityLogRepository activityLogRepository, UserManager<ApplicationUser> userManager, MediLogixDbContext dbContext)
    {
        if (context.Request.Path.StartsWithSegments("/api") &&
            !context.Request.Path.StartsWithSegments("/api/health"))
        {
            string userId = "anonymous";
            string firstName = "Anonymous";
            string lastName = "Anonymous";

            if (context.User?.Identity?.IsAuthenticated == true)
            {
                var userClaims = context.User.Claims.ToList();
                logger.LogDebug("All user claims: {Claims}", 
                    string.Join(", ", userClaims.Select(c => $"{c.Type}={c.Value}")));
                
                var nameIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);
                var nameIdDirectClaim = context.User.FindFirst("nameid");
                var emailClaim = context.User.FindFirst(ClaimTypes.Email) ?? context.User.FindFirst("email");
                var uniqueNameClaim = context.User.FindFirst("unique_name");
                
                if (nameIdClaim != null)
                {
                    userId = nameIdClaim.Value;
                    logger.LogDebug("UserId obtained from ClaimTypes.NameIdentifier: {UserId}", userId);
                }
                else if (nameIdDirectClaim != null)
                {
                    userId = nameIdDirectClaim.Value;
                    logger.LogDebug("UserId obtained from nameid claim: {UserId}", userId);
                }
                else if (emailClaim != null)
                {
                    var user = await userManager.FindByEmailAsync(emailClaim.Value);
                    if (user != null)
                    {
                        userId = user.Id;
                        logger.LogDebug("UserId obtained by email lookup: {UserId}", userId);
                    }
                    else
                    {
                        logger.LogWarning("Could not find user by email: {Email}", emailClaim.Value);
                    }
                }
                else if (uniqueNameClaim != null)
                {
                    var user = await userManager.FindByNameAsync(uniqueNameClaim.Value) ?? 
                              await userManager.FindByEmailAsync(uniqueNameClaim.Value);
                    if (user != null)
                    {
                        userId = user.Id;
                        logger.LogDebug("UserId obtained from unique_name lookup: {UserId}", userId);
                    }
                    else
                    {
                        logger.LogWarning("Could not find user by unique_name: {UniqueName}", uniqueNameClaim.Value);
                    }
                }

                if (userId != "anonymous")
                {
                    var nameClaim = context.User.Claims.FirstOrDefault(c => c.Type == "FirstName");
                    var lastNameClaim = context.User.Claims.FirstOrDefault(c => c.Type == "LastName");

                    if (nameClaim != null && lastNameClaim != null)
                    {
                        firstName = nameClaim.Value;
                        lastName = lastNameClaim.Value;
                        logger.LogDebug("Name and surname from claims: {FirstName} {LastName}", firstName, lastName);
                    }
                    else
                    {
                        if (emailClaim != null)
                        {
                            string email = emailClaim.Value;
                            logger.LogDebug("Looking up user by email: {Email}", email);
                            
                            var employee = await dbContext.Set<Employee>()
                                .FirstOrDefaultAsync(e => e.Email == email);

                            if (employee != null)
                            {
                                firstName = employee.FirstName;
                                lastName = employee.LastName;
                                logger.LogDebug("Name and surname found for email {Email}: {FirstName} {LastName}", 
                                    email, firstName, lastName);
                            }
                            else
                            {
                                var user = await dbContext.Users
                                    .OfType<ApplicationUser>()
                                    .Include(u => u.Employee)
                                    .FirstOrDefaultAsync(u => u.Email == email);

                                if (user?.Employee != null)
                                {
                                    firstName = user.Employee.FirstName;
                                    lastName = user.Employee.LastName;
                                    logger.LogDebug("Name and surname found via ApplicationUser->Employee relation: {FirstName} {LastName}", 
                                        firstName, lastName);
                                }
                            }
                        }
                        
                        if (firstName == "Anonymous" || lastName == "Anonymous")
                        {
                            var user = await dbContext.Users
                                .OfType<ApplicationUser>()
                                .Include(u => u.Employee)
                                .FirstOrDefaultAsync(u => u.Id == userId);

                            if (user?.Employee != null)
                            {
                                firstName = user.Employee.FirstName;
                                lastName = user.Employee.LastName;
                                logger.LogDebug("Name and surname from database by ID: {FirstName} {LastName}", firstName, lastName);
                            }
                            else 
                            {
                                logger.LogWarning("Could not find name information for user with ID {UserId}", userId);
                            }
                        }
                    }
                }
            }

            var originalBodyStream = context.Response.Body;
            var requestPath = context.Request.Path.ToString();
            var requestMethod = context.Request.Method;

            try
            {
                using var responseBody = new MemoryStream();
                context.Response.Body = responseBody;

                await next(context);

                var activityLog = new ActivityLog
                {
                    UserId = userId,
                    UserFirstName = firstName,
                    UserLastName = lastName,
                    Action = $"{requestMethod} {requestPath}",
                    Route = requestPath,
                    IpAddress = context.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                    Timestamp = DateTime.UtcNow + TimeSpan.FromHours(3),
                };

                await activityLogRepository.AddLogAsync(activityLog);

                logger.LogInformation(
                    "User ({FirstName} {LastName}) performed {Action} from IP {IpAddress} at {Timestamp}", firstName, lastName, activityLog.Action, activityLog.IpAddress, activityLog.Timestamp);

                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in logging middleware");
                throw;
            }
            finally
            {
                context.Response.Body = originalBodyStream;
            }
        }
        else
        {
            await next(context);
        }
    }
}