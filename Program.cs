using System;
using System.Collections.Generic;
using workflows.Models;

namespace workflows
{
    class Program
    {
        static void Main(string[] args)
        {
            var alwaysTrue = new AlwaysTrueValidation(Guid.NewGuid(), "nada", "ES LO MESMO");
            var alwaysBad = new AlwaysInvalidValidation(Guid.NewGuid(), "nada", "EXPLOTO!");
            var nameValidation = new NameNoEmptyValidation(Guid.NewGuid());
            var fieldNumberValidation = new FieldShouldContainOnlyNumbersValidation(Guid.NewGuid(), "Pepe");

            var nuevo = new State(Guid.NewGuid(), "Nuevo", false, false);
            var enviado = new State(Guid.NewGuid(), "enviado", false, false);
            var aprobado = new State(Guid.NewGuid(), "aprobado", true, true);
            var aprobadoParc = new State(Guid.NewGuid(), "aprobado parcialmnte", false, true);
            var rechazado = new State(Guid.NewGuid(), "rechazado", true, false);

            var changes = new List<Change>()
            {
                new Change(Guid.NewGuid(), "Envío", nuevo, enviado, new List<Validation>(){ alwaysTrue }),
                new Change(Guid.NewGuid(), "Rechazo de envió", enviado, rechazado),
                new Change(Guid.NewGuid(), "Necesita aprobacion de seguridad", enviado, aprobadoParc),
                new Change(Guid.NewGuid(), "Necesita comercial", aprobadoParc, aprobadoParc),
                new Change(Guid.NewGuid(), "Rechazo de preaprovado", aprobadoParc, rechazado),
                new Change(Guid.NewGuid(), "Aprobacion", aprobadoParc, aprobado),
                new Change(Guid.NewGuid(), "Aprobacion aútomatica", enviado, aprobado, new List<Validation>(){ fieldNumberValidation })
            };

            var wfDefault = new Workflow(Guid.NewGuid(), "Default WF", changes);

            var fao = new FAO()
            {
                Id = Guid.NewGuid(),
                Name = string.Empty,
                Pepe = "No soy un numero",
                Workflow = wfDefault,
                State = nuevo
            };

            // Change state
            fao.ApplyState(enviado);
            try
            {
                // Change state
                fao.ApplyState(aprobado);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
