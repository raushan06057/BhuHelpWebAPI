namespace BhuHelpAPI.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<ApplicationRole> roleManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly ApplicationDbContext Context;
    private readonly IConfiguration configuration;

    public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration) : base(context)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.signInManager = signInManager;
        this.configuration = configuration;
        this.Context = context;
    }

    public async Task<ResponseModel> CreateAsync(ApplicationUser user, List<Claim> claims)
    {
        ResponseModel responseModel = new();
        try
        {
            var existingUser = await userManager.FindByEmailAsync(user.Email);
            if (existingUser == null)
            {
                var result = await userManager.CreateAsync(user, user.Pwd);
                if (result.Succeeded)
                {
                    var role = await roleManager.FindByIdAsync(user.Role);
                    if (role == null)
                    {
                        ApplicationRole newRole = new() { Name = user.Role };
                        await roleManager.CreateAsync(newRole);
                        await userManager.AddToRoleAsync(user, newRole.Name);
                        if (claims != null)
                        {
                            await userManager.AddClaimsAsync(user, claims.AsEnumerable());
                        }
                        await context.SaveChangesAsync();
                    }
                    responseModel.Success = true;
                    responseModel.Message = CommonResource.RecordSavedSuccessfully;
                    responseModel.Data = user;
                }
                else
                {
                    responseModel.Success = false;
                    foreach (var error in result.Errors)
                    {
                        responseModel.Message = responseModel.Message + error.Description + ", ";
                    }
                }
            }
            else
            {
                responseModel.Success = false;
                responseModel.Message = CommonResource.RecordAlreadyExists;
            }
        }
        catch (Exception ex)
        {
            throw;
        }

        return responseModel;
    }

    public async Task<ResponseModel> GetAsync(ApplicationUser user)
    {
        var result = await (from usr in userManager.Users
                            join userRole in context.UserRoles on usr.Id equals userRole.UserId
                            join role in roleManager.Roles on userRole.RoleId equals role.Id
                            select new
                            {
                                UserId = usr.Id,
                                Username = usr.UserName,
                                Email = usr.Email,
                                RoleId = role.Id,
                                RoleName = role.Name,
                            }).ToListAsync();

        ResponseModel responseModel = new();
        responseModel.Success = true;
        responseModel.Data = result;
        return await Task.FromResult(responseModel);
    }

    public async Task<ResponseModel> LoginAsync(string userName, string password)
    {
        ResponseModel responseModel = new();
        var user = await userManager.FindByNameAsync(userName);
        if (user == null)
        {
            responseModel.Success = false;
            responseModel.Message = CommonResource.UserNotFound;
        }
        var result = await signInManager.CheckPasswordSignInAsync(user, password, false);
        if (!result.Succeeded)
        {
            responseModel.Success = false;
            responseModel.Message = CommonResource.InvalidUsernameorPassword;
        }
        if (result.Succeeded)
        {
            responseModel.Success = true;
            responseModel.Message = CommonResource.UserLoggedInSuccessfully;
            var token = GenerateJwtToken(user);
            responseModel.Data = token;
            responseModel.RoleName = user.Role;
        }
        return responseModel;
    }

    private string GenerateJwtToken(ApplicationUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[CommonFields.JwtColonKey] ?? "N/A"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
                new Claim(CommonFields.ID,Convert.ToString(user.Id)),
                new Claim(ClaimTypes.NameIdentifier,user.UserName??"N/A"),
                new Claim(CommonFields.UserId,Convert.ToString(user.Id)),
                new Claim(ClaimTypes.Role,user.Role),
            };
        var token = new JwtSecurityToken(configuration[CommonFields.JwtColonIssuer],
            configuration[CommonFields.JwtColonAudience],
            claims,
            expires: DateTime.Now.AddMinutes(3600),
            signingCredentials: credentials);
        var data = new JwtSecurityTokenHandler().WriteToken(token);
        return data;
    }

    public async Task<ResponseModel> GetAsync(string userId)
    {
        ResponseModel responseModel = new();
        responseModel.Success = true;
        var user = await userManager.Users.Where(mod => mod.Id == userId).FirstOrDefaultAsync();
        if (user != null)
        {
            var role = await roleManager.Roles.Where(mod => mod.Id == user.Role).FirstOrDefaultAsync();
            var result = new
            {
                Id = user.Id,
                RoleId = role?.Id,
                RoleName = role?.Name,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
            responseModel.Data = result;
        }
        return await Task.FromResult(responseModel);
    }

    public async Task<ResponseModel> UpdateAsync(ApplicationUser user, List<Claim> claims)
    {
        ResponseModel responseModel = new();
        try
        {
            var existingUser = await userManager.FindByIdAsync(user.Id);
            if (existingUser != null)
            {
                existingUser.Email = user.Email;
                existingUser.UserName = user.UserName;
                existingUser.PhoneNumber = user.PhoneNumber;
                var result = await userManager.UpdateAsync(existingUser);
                if (result.Succeeded)
                {
                    var role = await roleManager.FindByIdAsync(user.Role);
                    if (role == null)
                    {
                        ApplicationRole newRole = new() { Name = user.Role };
                        await roleManager.CreateAsync(newRole);
                        await userManager.AddToRoleAsync(user, newRole.Name);
                        if (claims != null)
                        {
                            await userManager.AddClaimsAsync(user, claims.AsEnumerable());
                        }
                        await context.SaveChangesAsync();
                    }
                    responseModel.Success = true;
                    responseModel.Message = CommonResource.RecordSavedSuccessfully;
                    responseModel.Data = user;
                }
                else
                {
                    responseModel.Success = false;
                    foreach (var error in result.Errors)
                    {
                        responseModel.Message = responseModel.Message + error.Description + ", ";
                    }
                }
            }
            //else
            //{
            //    responseModel.Success = false;
            //    responseModel.Message = CommonResource.RecordAlreadyExists;
            //}
        }
        catch (Exception ex)
        {
            throw;
        }
        return responseModel;
    }
}
