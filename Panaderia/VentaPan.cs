using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Panaderia
{
    public class VentaPan : INotifyPropertyChanged
    {
        public VentaPan()
        {
            Cargar();
            AgregarCommand = new RelayCommand<Productos>(Añadir);
            EliminarCommand = new RelayCommand(Eliminar);
            AcabarCommand = new RelayCommand(AcabarVenta);
        }

        public sbyte cantidad;
        public decimal Total;

        public ObservableCollection<Productos> Venta { set; get; } = new();

        public ICommand AgregarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        public ICommand AcabarCommand { get; set; }

        public Productos Producto { set; get; } = new();

        public ObservableCollection<Productos> Panes = new()
        {
            new Productos { pan = tipoPan.Quequito, precio = 10m, cantidad = 10, imagen = "1.png"},
            new Productos { pan = tipoPan.Dona, precio = 10m, cantidad = 10, imagen = "2.png"},
            new Productos { pan = tipoPan.Quaso, precio = 10m, cantidad = 10 },
            new Productos { pan = tipoPan.PanBlanco, precio = 10m, cantidad = 10 },
            new Productos { pan = tipoPan.GalletaChispas, precio = 10m, cantidad = 10 },
            new Productos { pan = tipoPan.QuequitoChispas, precio = 10m, cantidad = 10 },
            new Productos { pan = tipoPan.Pretzel, precio = 10m, cantidad = 10 },
            new Productos { pan = tipoPan.GalletaCuadrada, precio = 10m, cantidad = 10 },
            new Productos { pan = tipoPan.GalletaEstrella, precio = 10m, cantidad = 10 }
        };

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Añadir(Productos? p)
        {

            if (p != null)
            {
                //var PanVenta = new Productos
                //{
                //    pan = p.pan,
                //    cantidad = p.cantidad,
                //};


                //Productos a = Venta.FirstOrDefault(x => x.pan == p.pan);
               
                //if (p.cantidad > Panes.Where(p.))
                //{
                //    throw new ArgumentException("");
                //}
                //decimal cantidad = p.cantidad;
                //var total = from x in Panes where x.pan == p.pan select x.precio * p.cantidad;



                Venta.Add(p);
                Producto = new();
                PropertyChanged?.Invoke(this, new(nameof(Producto)));
            }
            Guardar();
        }

        public void Eliminar()
        {

            if (Venta != null)
            {
                Venta.Remove(Producto);
                Guardar();
            }
        }

        public void AcabarVenta()
        {
            if (Venta != null)
            {
                Venta.Clear();
                Guardar();
            }
        }
        string guardado = "venta.json";
        public void Guardar()
        {
            var json = JsonSerializer.Serialize(Venta);
            File.WriteAllText(guardado, json);
        }

        public void Cargar()
        {
            if (File.Exists(guardado))
            {
                string json = File.ReadAllText(guardado);
                var panes = JsonSerializer.Deserialize<ObservableCollection<Productos>>(json);

                if (panes != null)
                {
                    foreach (var pan in panes)
                    {
                        Venta.Add(pan);
                    }
                }
            }
        }

    }
}
