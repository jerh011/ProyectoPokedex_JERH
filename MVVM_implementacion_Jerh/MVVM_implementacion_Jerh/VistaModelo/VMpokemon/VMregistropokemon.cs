﻿using MVVM_implementacion_Jerh.Vista;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MVVM_implementacion_Jerh.Modelo;
using MVVM_implementacion_Jerh.Datos;

namespace MVVM_implementacion_Jerh.VistaModelo.VMpokemon
{
    public class VMregistropokemon: BaseViewModel
    {
        ////////////////////////////


       #region VARIABLES
        string _TxtColorFondo;
        string _TxtColorPoder;
        string _TxtNombre;
        string _TxtNro;
        string _TxtPoder;
        string _TxtIcono;
        string _TxtID;
        #endregion
        #region Contructor
        public VMregistropokemon(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region Objetivo;
        public string TxtColorFondo
        {
            get { return _TxtColorFondo; }
            set { SetValue(ref _TxtColorFondo, value); }
        }
        public string TxtColorPoder
        {
            get { return _TxtColorPoder; }
            set { SetValue(ref _TxtColorPoder, value); }
        }
        public string TxtNombre
        {
            get { return _TxtNombre; }
            set { SetValue(ref _TxtNombre, value); }
        }
        //public string TxtID
        //{
        //    get { return _TxtID; }
        //    set { SetValue(ref _TxtID, value); }
        //}
        public string TxtNro
        {
            get { return _TxtNro; }
            set { SetValue(ref _TxtNro, value); }
        }
        public string TxtPoder
        {
            get { return _TxtPoder; }
            set { SetValue(ref _TxtPoder, value); }
        }
        public string TxtIcono
        {
            get { return _TxtIcono; }
            set { SetValue(ref _TxtIcono, value); }
        }

        #endregion
        #region PROCESOS
        public async Task Insertar() {
            var funcion = new DPokemon(); 
            var parametros = new Mpokemon();
            parametros.Colorfondo = TxtColorFondo;
            parametros.ColorPoder = TxtColorPoder;
            parametros.Icono= TxtIcono;
            parametros.Nombre= TxtNombre;
            parametros.NroOrden = TxtNro;
            parametros.Poder= TxtPoder;
            await funcion.Insertarpokemon(parametros);
            await Volver();
        }

        public async Task Eliminar(Mpokemon mpokemon) {

            var funcion = new DPokemon();
            await funcion.Eliminarpokemon(mpokemon.Idpokemon);
        }

        public async Task Volver()
        {
            await Navigation.PopAsync();
        }



        #endregion.
        #region CONTRUCTOR

        #endregion.
        #region COMANDOS
        public ICommand Insertarcommand => new Command(async () => await Insertar());

        public ICommand Volvercommand => new Command(async () => await Volver());
       
        #endregion







        ///////////////////////////


    }
}
