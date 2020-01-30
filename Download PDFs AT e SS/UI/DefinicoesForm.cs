﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Download_PDFs_AT_e_SS.Forms
{
    public partial class DefinicoesForm : Form
    {
        public DefinicoesForm()
        {
            InitializeComponent();

            BindingList<DefinicoesExportTipoReciboVerde> listaDefExport = new BindingList<DefinicoesExportTipoReciboVerde>();
            listaDefExport.Add(Definicoes.definicoesExportacao.defExportFaturaRecibo.defExportTipoPagamento);
            listaDefExport.Add(Definicoes.definicoesExportacao.defExportFaturaRecibo.defExportTipoAdiantamento);
            listaDefExport.Add(Definicoes.definicoesExportacao.defExportFaturaRecibo.defExportTipoAdiantamentoPagamento);
            listaDefExport.Add(Definicoes.definicoesExportacao.defExportFatura.defExportTipoPagamento);
            listaDefExport.Add(Definicoes.definicoesExportacao.defExportFatura.defExportTipoAdiantamento);
            listaDefExport.Add(Definicoes.definicoesExportacao.defExportFatura.defExportTipoAdiantamentoPagamento);
            listaDefExport.Add(Definicoes.definicoesExportacao.defExportRecibo.defExportTipoPagamento);
            listaDefExport.Add(Definicoes.definicoesExportacao.defExportRecibo.defExportTipoAdiantamento);
            listaDefExport.Add(Definicoes.definicoesExportacao.defExportRecibo.defExportTipoAdiantamentoPagamento);


            dataGridView1.DataSource = listaDefExport;
            dataGridView1.CellEnter += (sender, e) => ((DataGridView)sender).BeginEdit(true);
        }

        bool saveDefinicoes = false;

        private void btnOK_Click(object sender, EventArgs e)
        {
            saveDefinicoes = true; //Informa que quando o form fechar não é para fazer reset às definicoes
            Definicoes.Save();
            Close();
        }

        private void DefinicoesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!saveDefinicoes)
            {
                //Se não tiver carregado no OK, faz reset às definicoes
                Definicoes.Load();
            }
        }
    }
}
