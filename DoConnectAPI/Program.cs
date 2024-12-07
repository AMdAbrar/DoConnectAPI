    using System.Text;
    using DoConnectRepositoty.Data;
    using DoConnectRepositoty.Repository;
    using DoConnectService.Services;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
// it is a middlewate it will check the user and database credential are same
    var builder = WebApplication.CreateBuilder(args);

// Configure NLog
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();   
    logging.SetMinimumLevel(LogLevel.Trace);
});

// Add NLog as the logger provider
builder.Services.AddSingleton<ILoggerProvider, NLogLoggerProvider>();

// Add services to the container.
var sqlconnectionstring = builder.Configuration.GetConnectionString("sqlcon");
    builder.Services.AddDbContext<UserDbConnect>(options => options.UseSqlServer(sqlconnectionstring));
    builder.Services.AddScoped<IAuthoUserService, AuthoUserService>();
    builder.Services.AddScoped<IAuthUserRepo, AuthUserRepo>();
    builder.Services.AddScoped<IUserServices, UserServices>();
    builder.Services.AddScoped<IDoConnectRepo, DoConnectRepo>();
    builder.Services.AddScoped<IDoConnectService, DoConnectRegisterService>();
builder.Services.AddScoped<IUserData, UserData>(); 

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddDbContext<UserDbConnect>
        (options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));
    //builder.Services.AddTransient<IAuthoUserService, AuthoUserService>();
    //builder.Services.AddTransient<IAuthUserRepo, AuthUserRepo>();
    builder.Services.AddControllers();

    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Movie API",
            Description = "Movie Management System API",
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme."

        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                              new OpenApiSecurityScheme
                              {
                                  Reference = new OpenApiReference
                                  {
                                      Type = ReferenceType.SecurityScheme,
                                      Id = "Bearer"
                                  }
                              },
                             new string[] {}
                        }
                    });
    });

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddControllers();

var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
