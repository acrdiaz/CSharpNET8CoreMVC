using System.Net.Mime;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", (HttpContext context) => "Hi Get");
app.MapGet("/", (HttpContext context) =>
{
    string html = $@"
        <!DOCTYPE html>
        <html>
        <head>
            <title>Home Page</title>
        </head>
        <body>
            <h1>Home Page</h1>
            <p>Welcome to the Home Page</p>
            <form action='/login' method='post'>
                <label for='username'>User name:</label>
                <input type='text' id='username' name='username' />
                <label for='password'>Password:</label>
                <input type='password' id='password' name='password' />

                <button type='submit'>Login</button>
            </form>
        </body>
        </html>";

    WriteHtml(context, html);
});

app.MapPost("/login", (HttpContext context) =>
{
    string username = context.Request.Form["username"];
    string password = context.Request.Form["password"];

    if (username == "frank" && password == "password")
    {
        string html = $@"
        <!DOCTYPE html>
        <html>
        <head>
            <title>Home Page</title>
        </head>
        <body>
            <h1>Login Page</h1>
            <p>Welcome {username} to our site</p>
            <p>Your password is {password}</p>
        </body>
        </html>";
        WriteHtml(context, html);
    }
    else
    {
        string html = $@"
        <!DOCTYPE html>
        <html>
        <head>
            <title>Home Page</title>
        </head>
        <body>
            <h1>Home Page</h1>
            <p>Welcome to the Home Page</p>
            <form action='/login' method='post'>
                <label for='username'>User name:</label>
                <input type='text' id='username' name='username' />
                <label for='password'>Password:</label>
                <input type='password' id='password' name='password' />

                <button type='submit'>Login</button>
                <br/>
                <label style='color:red'>Invalid username or password</label>
            </form>
        </body>
        </html>";

        WriteHtml(context, html);
    }
});

app.Run();

void WriteHtml(HttpContext context, string html)
{
    context.Response.ContentType = MediaTypeNames.Text.Html;
    context.Response.ContentLength = Encoding.UTF8.GetByteCount(html);
    context.Response.WriteAsync(html);
}