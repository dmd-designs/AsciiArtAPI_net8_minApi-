using System.Text;
using Figgle;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/asciiart", (string ascii, string font) =>
{
    if (ascii is null) return FiggleFonts.Standard.Render(ascii);
    switch (font)
    {
        case "Graffiti":
            return FiggleFonts.Graffiti.Render(ascii);
        case "Acrobatic":
            return FiggleFonts.Acrobatic.Render(ascii);
        case "Alligator":
            return FiggleFonts.Alligator.Render(ascii);
        case "Alligator2":
            return FiggleFonts.Alligator2.Render(ascii);
        case "Alligator3":
            return FiggleFonts.Alligator3.Render(ascii);
        case "Arrows":
            return FiggleFonts.Arrows.Render(ascii);
        default:
            return FiggleFonts.Standard.Render(ascii);
    }
});
app.MapGet("/graffiti", (string figgleString) =>
{
    var figgleGraffiti = FiggleFonts.Graffiti.Render(figgleString);
    figgleGraffiti ??= "No Text Was Received!";

    Console.Write(FiggleFonts.Graffiti.Render(figgleString));
    return FiggleFonts.Graffiti.Render(figgleString);
});

app.Run();

