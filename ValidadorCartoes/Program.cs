using ValidadorCartoes.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

bool executar = true;
while (executar)
{
    Console.WriteLine("Deseja verificar a bandeira de um cartão de crédito? (S/N)");
    var resposta = Console.ReadLine();
    if (resposta?.ToUpper() != "S")
    {
        executar = false;
        continue;
    }

//chamar o service
Console.WriteLine("Digite o número do cartão de crédito:");
var numeroCartao = Console.ReadLine();
var bandeira = CartaoService.ObterBandeiraPorRegex(numeroCartao);
Console.WriteLine($"A bandeira do cartão {numeroCartao} é {bandeira}");

}


app.Run();




