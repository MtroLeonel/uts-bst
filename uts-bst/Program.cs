using uts_bst;

ArbolBinarioBusqueda agenda = new ArbolBinarioBusqueda();

// Carga inicial de datos
int[] estudiantesIniciales = { 50, 30, 70, 20, 40, 60, 80 };
foreach (int id in estudiantesIniciales)
{
    agenda.Insertar(id);
}

bool continuar = true;

while (continuar)
{
    Console.Clear();
    Console.WriteLine("==================================================");
    Console.WriteLine("     SISTEMA DE GESTIÓN DE IDs DE ESTUDIANTES     ");
    Console.WriteLine("==================================================");

    Console.Write("IDs registrados (Ordenados): ");
    agenda.ImprimirInorden();
    Console.WriteLine("--------------------------------------------------");

    Console.WriteLine("1. Insertar estudiante");
    Console.WriteLine("2. Buscar estudiante");
    Console.WriteLine("3. Eliminar estudiante");
    Console.WriteLine("4. Salir");
    Console.WriteLine("--------------------------------------------------");
    Console.Write("Seleccione una opción: ");

    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Write("\nIngrese el ID a registrar: ");
            if (int.TryParse(Console.ReadLine(), out int nuevoId))
            {
                if (agenda.Buscar(nuevoId))
                {
                    Console.WriteLine($"\n[!] El ID {nuevoId} ya existe en el árbol.");
                }
                else
                {
                    agenda.Insertar(nuevoId);
                    Console.WriteLine($"\n[✓] ID {nuevoId} registrado correctamente.");
                }
            }
            else
            {
                Console.WriteLine("\n[X] Entrada inválida. Debe ingresar un número entero.");
            }
            Pausar();
            break;

        case "2":
            Console.Write("\nIngrese el ID a buscar: ");
            if (int.TryParse(Console.ReadLine(), out int idBuscar))
            {
                bool existe = agenda.Buscar(idBuscar);
                if (existe)
                {
                    Console.WriteLine($"\n[✓] El alumno con ID {idBuscar} está registrado.");
                }
                else
                {
                    Console.WriteLine($"\n[X] El alumno con ID {idBuscar} NO se encuentra registrado.");
                }
            }
            else
            {
                Console.WriteLine("\n[X] Entrada inválida. Debe ingresar un número entero.");
            }
            Pausar();
            break;

        case "3":
            Console.Write("\nIngrese el ID a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int idEliminar))
            {
                if (!agenda.Buscar(idEliminar))
                {
                    Console.WriteLine($"\n[X] El ID {idEliminar} no existe en el sistema.");
                }
                else
                {
                    agenda.Eliminar(idEliminar);
                    Console.WriteLine($"\n[✓] Alumno con ID {idEliminar} eliminado con éxito.");
                }
            }
            else
            {
                Console.WriteLine("\n[X] Entrada inválida. Debe ingresar un número entero.");
            }
            Pausar();
            break;

        case "4":
            continuar = false;
            Console.WriteLine("\nCerrando el sistema...");
            break;

        default:
            Console.WriteLine("\n[!] Opción no válida. Intente nuevamente.");
            Pausar();
            break;
    }
}

static void Pausar()
{
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}