using TCCII.Infrastructure.ChargeDatabase;

Console.WriteLine("Hello, World!");
try
{
    DeputadosCharge.CargaDeputados();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}