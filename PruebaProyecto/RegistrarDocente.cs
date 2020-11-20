﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;

namespace PruebaProyecto
{
    public partial class RegistrarDocente : Form
    {

        DocenteserviceBD service;
        public RegistrarDocente()
        {
            InitializeComponent();
            service = new DocenteserviceBD(ExtraerCadena.connectionString);
            btRegistrarAsignatura.Visible = false;
        }

        private void btRegistrarAsignatura_Click(object sender, EventArgs e)
        {
            RegistrarAsignatura registrarAsignatura = new RegistrarAsignatura();
            PasarTexto(registrarAsignatura);
            registrarAsignatura.Show();
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            Docente docente = new Docente();
            docente.Identificacion = txtIdentificacion.Text;
            docente.primerNombre = txtPrimerNombre.Text;
            docente.segundoNombre = txtSeguundoNombre.Text;
            docente.primerApellido = txtPrimerApellido.Text;
            docente.segundoApellido = txtSegundoApellido.Text;
            docente.Email = txtEmail.Text;
            docente.nombreDeUsuario = txtNombreUsuario.Text;
            docente.contraseña = txtContraseña.Text;
            MessageBox.Show(service.Guardar(docente), "Registro", MessageBoxButtons.OK);
            btRegistrarAsignatura.Visible = true;
        }

        public void PasarTexto(RegistrarAsignatura registrar)
        {
            registrar.textBox5.Text = txtIdentificacion.Text;
        }
       
    }
}
