using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClimaTempo.Models;
using ClimaTempo.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ClimaTempo.ViewModels
{
    public partial class PrevisaoViewModel : ObservableObject
    {
        [ObservableProperty]
        private string cidade;

        [ObservableProperty]
        private string estado;

        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private DateTime data;

        [ObservableProperty]
        private string condicao;

        [ObservableProperty]
        private double min;

        [ObservableProperty]
        private double max;

        [ObservableProperty]
        private double indice_uv;

        [ObservableProperty]
        private List<Clima> proximosDias;
        
        private Previsao previsao;
        private Previsao proxPrevisao;

        private List<Cidade> cidades;


        public ICommand BuscarPrevisaoCommand { get; }
        public ICommand BuscarCidadesCommand { get; }

        public PrevisaoViewModel()
        {
            BuscarPrevisaoCommand = new Command(BuscarPrevisao);
            BuscarCidadesCommand = new Command(BuscarCidades);
    }

        public async void BuscarPrevisao()
        {
            //Busca os dados da previsão para uma cidade especificada
            previsao = await new PrevisaoService().GetPrevisaoById(244);
            Cidade = previsao.Cidade;
            Estado = previsao.Estado;
            Data = previsao.clima[0].Data;
            Max = previsao.clima[0].Max;
            Min = previsao.clima[0].Min;
            Condicao = previsao.clima[0].Condicao;
            Indice_uv = previsao.clima[0].Indice_uv;

            //Busca os dados da previsão para os próximos dias
            proxPrevisao = await new PrevisaoService().GetPrevisaoForXDaysById(244, 3);
            ProximosDias = proxPrevisao.clima;

        }

        public async void BuscarCidades()
        {

        }
    }
}
