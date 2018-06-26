using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeLife.Negocio;

namespace BeLife.UnitTest
{
    [TestClass]
    public class VehiculoTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange 
            var resultadoEsperado = true;


            var idMarca = 1;
            var nombreMarca = "Marca 1";

            var idModelo = 1;
            var nombreModelo = "Modelo 1";

            var annio = 1999;
            var patente = "Patente 1";

            Marca marca = new Marca()
            {
                Id = idMarca,
                Nombre = nombreMarca
            };
            Modelo modelo = new Modelo
            {
                Id = idModelo,
                Nombre = nombreModelo
            };
            MarcaModelo marcaModelo = new MarcaModelo()
            {
                Marca = marca,
                Modelo = modelo
            };

            Vehiculo vehiculo = new Vehiculo()
            {
                Patente = patente,
                IdMarca = marca.Id,
                IdModelo = modelo.Id,
                Anho = annio,
                MarcaModelo = marcaModelo
            };

            //Act
            var resultado = vehiculo.Create();

            //Assert 
            Assert.AreEqual(resultadoEsperado,resultado);
        }
    }
}
