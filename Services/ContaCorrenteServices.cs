using AutoMapper;
using Domain;
using Entities;
using Repositories;
using System.Threading.Tasks;
using ViewModels;

namespace Services
{
    public class ContaCorrenteServices : IContaCorrenteServices
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly MapperConfiguration _mapperConfiguration;

        public ContaCorrenteServices(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;

            _mapperConfiguration = new MapperConfiguration(cfg => { cfg.CreateMap<ContaCorrente, ContaCorrenteModel>(); });
        }

        public async Task<decimal> ObterSaldoContaCorrente(long conta)
        {
            var contaCorrente = await _contaCorrenteRepository.ObterConta(conta);

            new ValidacaoConta(contaCorrente).Validar();

            return contaCorrente.Saldo;
        }

        public async Task<ContaCorrenteModel> Sacar(MovimentacaoConta movimentacao)
        {
            var conta = await _contaCorrenteRepository.ObterConta(movimentacao.Conta);
            
            new ValidacaoConta(conta).Validar();
            new ValidacaoSaldo(conta, movimentacao).Validar();
            
            conta.Saldo -= movimentacao.Valor;

            await _contaCorrenteRepository.Alterar(conta);

            return _mapperConfiguration.CreateMapper().Map<ContaCorrente, ContaCorrenteModel>(conta);
        }

        public async Task<ContaCorrenteModel> Depositar(MovimentacaoConta movimentacao)
        {
            var conta = await _contaCorrenteRepository.ObterConta(movimentacao.Conta);
            new ValidacaoConta(conta).Validar();
            conta.Saldo += movimentacao.Valor;

            await _contaCorrenteRepository.Alterar(conta);

            return _mapperConfiguration.CreateMapper().Map<ContaCorrente, ContaCorrenteModel>(conta);
        }

        public void Dispose()
        {
            _contaCorrenteRepository?.Dispose();
        }
    }
}
