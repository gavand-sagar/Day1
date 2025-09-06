using Day2;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddResponseCaching();
builder.Services.AddMemoryCache(options =>
{
    options.SizeLimit = 1024; 
});
// Add services to the container.
builder.Services.AddCors(builder =>
{
    builder.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});
var jwtSettings = builder.Configuration.GetSection("JwtSettings");


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
            };
        });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterValidators();

builder.Services.AddAutoMapper((c) => { }, typeof(Program).Assembly);

//builder.Services.AddRateLimiter(options =>
//{
//    //options.AddFixedWindowLimiter(policyName: "Fixed", options =>
//    //{
//    //    options.PermitLimit = 1000;
//    //    options.Window = TimeSpan.FromSeconds(10);
//    //    options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
//    //    options.QueueLimit = 5; // how many to be on hold until slot is being free
//    //});

//    //options.AddSlidingWindowLimiter(policyName: "Sliding", options =>
//    //{
//    //    options.PermitLimit = 5;
//    //    options.SegmentsPerWindow = 2;
//    //    options.Window = TimeSpan.FromSeconds(10);
//    //    options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
//    //    options.QueueLimit = 2; // how many to be on hold until slot is being free
//    //});

//    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
//    {
//        // only 5 requests per 10 seconds from a single IP Address

//        //var ip = httpContext.Connection.RemoteIpAddress.ToString();

//        // only 5 requests per 10 seconds from a single user

//        string username = httpContext.Request.Headers["my-name"].ToString();
//        return RateLimitPartition.GetFixedWindowLimiter(partitionKey: username, factory: partition =>
//        {
//            return new FixedWindowRateLimiterOptions
//            {
//                PermitLimit = 5,
//                QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
//                QueueLimit = 0,
//                Window = TimeSpan.FromSeconds(10)
//            };
//        });
//    });
//});

var app = builder.Build();
app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCaching();

//app.UseRateLimiter();

app.MapControllers();

app.Run();
