using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Vote.BL;
using Vote.Model;
using Vote.Model.Interfaces;

namespace Vote.ViewModel
{
    public class VotePageViewModel : ViewModelBase
    {
        private readonly ApiCommunicator _apiCommunicator;
        private readonly INavigationManager _navigationManager;
        private ObservableCollection<Candidate> _availableCandidates;
        private ObservableCollection<District> _availablePsis;
        private Candidate _chosenCandidate;
        private District _chosenPsi;
        private bool _loading;
        private List<Candidate> _allCandidates;

        private string _vit;
        private bool _canChooseCandidate;

        public VotePageViewModel(INavigationManager navigationManager, ApiCommunicator apiCommunicator)
        {
            _chosenCandidate = new Candidate();
            _navigationManager = navigationManager;
            _apiCommunicator = apiCommunicator;

            VoteCommand = new RelayCommand(Vote,
                () => ChosenCandidate != null && !string.IsNullOrEmpty(Vit) && ChosenPsi != null);
        }

        public async void NavigatedTo()
        {
            Loading = true;
            AvailablePsis = await _apiCommunicator.GetDistrict();
            _allCandidates = await _apiCommunicator.GetCandidates();
            Loading = false;
        }

        public ObservableCollection<Candidate> AvailableCandidates
        {
            get => _availableCandidates;
            set
            {
                _availableCandidates = value;
                CanChooseCandidate = value?.Any() ?? false;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<District> AvailablePsis
        {
            get => _availablePsis;
            set
            {
                _availablePsis = value;
                RaisePropertyChanged();
            }
        }

        public bool Loading
        {
            get => _loading;
            set
            {
                _loading = value;
                RaisePropertyChanged();
            }
        }

        public bool CanChooseCandidate
        {
            get => _canChooseCandidate;
            set
            {
                _canChooseCandidate = value;
                RaisePropertyChanged();
            }
        }

        public string Vit
        {
            get => _vit;
            set
            {
                _vit = value;
                RaisePropertyChanged();
                VoteCommand.RaiseCanExecuteChanged();
            }
        }

        public Candidate ChosenCandidate
        {
            get => _chosenCandidate;
            set
            {
                _chosenCandidate = value;
                RaisePropertyChanged();
                VoteCommand.RaiseCanExecuteChanged();
            }
        }

        public District ChosenPsi
        {
            get => _chosenPsi;
            set
            {
                _chosenPsi = value;
                ChosenCandidate = null;
                if (value != null)
                    AvailableCandidates =
                        new ObservableCollection<Candidate>(
                            _allCandidates.Where(candidate => candidate.Psi == value.Psi));
                else
                    AvailableCandidates = new ObservableCollection<Candidate>();

                RaisePropertyChanged();
                VoteCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand VoteCommand { get; }

        private async void NewCandidate(Candidate candidate)
        {
            var created = await _apiCommunicator.NewCandidate(candidate);
        }

        private async void NewDistrict(District dist)
        {
            var created = await _apiCommunicator.NewPsi(dist);
        }

        private async void Vote()
        {
            Loading = true;
            var result = await _apiCommunicator.SendVote(new Model.Vote
            {
                DistrictPsi = ChosenPsi.Psi,
                Timestamp = DateTime.UtcNow.ToBinary(),
                Candidate = ChosenCandidate,
                Vit = Vit
            });
            Loading = false;

            if (!result)
                MessageBox.Show("Wystąpił błąd podczas oddawania głosu.", "Warning", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            else
                MessageBox.Show($"Zagłosowano na: {ChosenCandidate.Name} {ChosenCandidate.Surname} Vit: {Vit}");


            ChosenCandidate = null;
            ChosenPsi = null;
            Vit = null;
        }
    }
}