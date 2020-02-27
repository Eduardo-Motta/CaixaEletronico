using Xunit;
using Moq;
using Entities;
using Repositories;
using Services;
using System.Threading.Tasks;
using Domain.Exceptions;
using ViewModels;
using Entities.Domain.Exceptions;

namespace Tests.Services
{
    public class ContaCorrenteServicesTest : Base
    {
        [Fact(DisplayName = "validar conta corrente com código não cadastrado")]
        public void ValidarContaCorrenteNaoCadastrada()
        {
            var moq = new Mock<IRepository>();

            moq.Setup(x => x.Obter<ContaCorrente>(2222)).Returns(ObterContaCorrente1111());

            var contaCorrenteServices = new ContaCorrenteServices(new ContaCorrenteRepository(moq.Object));

            Assert.ThrowsAsync<ContaNaoEncontradaException>(async () => await contaCorrenteServices.ObterSaldoContaCorrente(222));
        }

        [Fact(DisplayName = "Validar consulta do saldo da conta")]
        public async void ValidarConsultaSaldoConta()
        {
            var moq = new Mock<IRepository>();

            moq.Setup(x => x.Obter<ContaCorrente>(It.IsAny<long>())).Returns(Task.FromResult(new ContaCorrente
            {
                Conta = 1111,
                Saldo = 120
            }));

            var contaCorrenteServices = new ContaCorrenteServices(new ContaCorrenteRepository(moq.Object));

            var atual = await contaCorrenteServices.ObterSaldoContaCorrente(1111);

            Assert.Equal(120, decimal.Parse(atual.ToString()));

        }

        [Fact(DisplayName = "Validar saldo da conta após um valor de saque inferior ao saldo da conta")]
        public async void ValidarSaqueInferiorAoSaldo()
        {
            var moq = new Mock<IRepository>();

            moq.Setup(x => x.Obter<ContaCorrente>(It.IsAny<long>())).Returns(Task.FromResult(new ContaCorrente
            {
                Conta = 1111,
                Saldo = 120
            }));

            var contaCorrenteServices = new ContaCorrenteServices(new ContaCorrenteRepository(moq.Object));

            var atual = await contaCorrenteServices.Sacar(new MovimentacaoConta(1111, 20));

            Assert.Equal(100, ((dynamic)atual).Saldo);

        }

        [Fact(DisplayName = "Validar saldo da conta após deposito")]
        public async void ValidaSaldoPosDeposito()
        {
            var moq = new Mock<IRepository>();

            moq.Setup(x => x.Obter<ContaCorrente>(It.IsAny<long>())).Returns(Task.FromResult(new ContaCorrente
            {
                Conta = 1111,
                Saldo = 120
            }));

            var contaCorrenteServices = new ContaCorrenteServices(new ContaCorrenteRepository(moq.Object));

            var atual = await contaCorrenteServices.Depositar(new MovimentacaoConta(1111, 20));

            Assert.Equal(140, ((dynamic)atual).Saldo);
        }

        [Fact(DisplayName = "Validar saque maior que o saldo na conta")]
        public void ValidarSaqueSuperior()
        {
            var moq = new Mock<IRepository>();

            moq.Setup(x => x.Obter<ContaCorrente>(It.IsAny<long>())).Returns(Task.FromResult(new ContaCorrente
            {
                Conta = 1111,
                Saldo = 120
            }));

            var contaCorrenteServices = new ContaCorrenteServices(new ContaCorrenteRepository(moq.Object));

            Assert.ThrowsAsync<SaldoInsuficienteException>(async () => await contaCorrenteServices.Sacar(new MovimentacaoConta(1111, 2000)));
        }
    }
}