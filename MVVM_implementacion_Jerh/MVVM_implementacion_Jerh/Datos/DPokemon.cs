﻿using System;
using System.Collections.Generic;
using System.Text;
using MVVM_implementacion_Jerh.Modelo;
using MVVM_implementacion_Jerh.Conexion;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Firebase.Database;
using Xamarin.Essentials;
using LiteDB;

namespace MVVM_implementacion_Jerh.Datos
{
    public class DPokemon
    {
        public async Task Insertarpokemon(Mpokemon parametros)
        {
            await Cconexion.firebase.Child("Pokemon").PostAsync(new Mpokemon
            {
                Colorfondo = parametros.Colorfondo,
                ColorPoder = parametros.ColorPoder,
                Icono = parametros.Icono,
                Nombre = parametros.Nombre,
                NroOrden = parametros.NroOrden,
                Poder = parametros.Poder

            });

        }
        /*public async Task<ObservableCollection<Mpokemon>> MostrarPokemon()
        {
            var data = await Task.Run(() => Cconexion.firebase
          .Child("Pokemon")
          .AsObservable<Mpokemon>()
          .AsObservableCollection()
          .Select(async item => new Mpokemon
          {
              Idpokemon =item.Key,
              Nombre = item.Nombre,
              Colorfondo = item.Colorfondo,
              ColorPoder = item.Colorfondo,
              Icono = item.Icono,
              NroOrden = item.NroOrden,
              Poder = item.Poder

          }));


            return data;
        }*/
        public async Task<List<Mpokemon>> MostrarPokemon2()
        { 
        return (await Cconexion.firebase.Child("Pokemon")
                .OnceAsync<Mpokemon>())
                .Select(item=>new Mpokemon
                { 
                    Idpokemon=item.Key,
                    Nombre=item.Object.Nombre,
                    Colorfondo = item.Object.Colorfondo,
                    ColorPoder = item.Object.ColorPoder,
                    Icono = item.Object.Icono,
                    NroOrden = item.Object.NroOrden,
                    Poder = item.Object.Poder

                }).ToList();
            
            

        }

        public async Task Eliminarpokemon(Mpokemon mpokemon)
        {
            string id = mpokemon.Idpokemon;
            await Cconexion.firebase.Child("Pokemon").Child(id).DeleteAsync();
        }


        public async Task Actualizar(Mpokemon parametros)
        {
            await Cconexion.firebase.Child("Pokemon").Child(parametros.Idpokemon).PutAsync(new Mpokemon
            {
                Colorfondo = parametros.Colorfondo,
                ColorPoder = parametros.ColorPoder,
                Icono = parametros.Icono,
                Nombre = parametros.Nombre,
                NroOrden = parametros.NroOrden,
                Poder = parametros.Poder

            });

        }

    }
}