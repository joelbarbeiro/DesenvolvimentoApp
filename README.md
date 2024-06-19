# iCantine

## Descrição
iCantine é uma aplicação para gestão de reservas de refeições em cantinas escolares. 
Permite-nos visualizar o menu do dia, reservar refeições, consultar o histórico de reservas, permite também a gestão de utilizadores, pratos, menus e extras.

## Elementos do  Grupo
- André Barroso -  2231438
- Joel Barbeiro - 2232356
- Pedro Lourenço - 2232494

## Pré-requisitos
- .NET Framework 4.7.2 ou superior
- SQL Server 2017 ou superior
- Entity Framework Core 6

## Instalação

1. **Clone ao Respositório**

    >[Repositório](https://github.com/joelbarbeiro/DesenvolvimentoApp)

2. **Abrir a solução no Visual Studio**
    - Ir até a pasta onde está o clone do repositório e abrir o ficheiro `iCantine.sln` com o Visual Studio.

3. **Configurar a Base de Dados**
    - Ter a certeza que tem o SQL Server 2017 instalado nos Individual Components do Visual Studio Installer.
    - Certificar-se que o Entity Framework está instalado através do NuGet Package Manager.
    - Abrir o Package Manager Console `(Tools > NuGet Package Manager > Package Manager Console)` e correr o comando `Update-Database` para criar a base de dados.

## Execução

1. **Compilar a Solução**
    - Clicar em `Build > Build Solution`.

2. **Executar a Aplicação**
    - Clicar em `Debug > Start Debugging` ou `F5`.

## Utilização
Quando a aplicação é executada alguns dados são inseridos automaticamente na base de dados, como pratos, extras e menus para mais fácil utilização.
1. **Registo**
    - Para utilizar a aplicação é preciso registar-se como funcionário.

2. **Login**
    - Após o registo, fazer login com as credenciais criadas.

3. **Criar cliente**
    - Para criar um cliente é clicar em `Clientes` no formulário principal e clicar em `Registar` e escolher o tipo de cliente, Estudante ou Docente.
    - Para o estudante é preciso inserir o número de aluno e para o docente o email.

4. **Criar menu**
    - Para criar um menu é clicar em `Menus` no formulário principal e clicar em `Adicionar Menu` e escolher o dia da semana e os pratos que o compõem, os extras e a hora de refeição (Almoço ou Jantar).

5. **Reservar refeição**
    - Para reservar uma refeição é clicar em `Reservas` no formulário principal e clicar em `Efetuar Reservas` e escolher o cliente, o menu, data de reserva, extras e clicar em `Reservar`.

6. **Consultar histórico de reservas**
    - Para consultar o histórico de reservas é clicar em `Reservas` no formulário principal e clicar em `Reservas efetuadas`. 
    - Nesse formulário, tem a opção de passar as reservas feitas para reservas utilizadas.

7. **Consultar e alterar multas**
    - Para consultar e alterar multas é clicar em `Multas` no formulário principal e clicar em `Consultar Multas`.
    - Nesse formulário, tem a opção de adicionar, editar ou remover multas e também modificá-las.

8. **Consultar e alterar utilizadores**
    - Em qualquer formulário podemos ver qual o funcionário atual e pode-se também clicar em `Funcionários` e mudar de funcionário.

9. **Criar pratos**
    - Para criar pratos é clicar em `Pratos` no formulário principal.
    - Depois de clicar tem as opções para criar, editar e remover pratos.

9. **Criar extras**
    - Para criar extras é clicar em `Extras` no formulário principal.
    - Depois de clicar tem as opções para criar, editar e remover extras e também alterar os preços deles.

10. **Logout**
    - Para fazer logout é clicar em `Logout` no canto superior direito.
    
11. **Recibos e Invoices**
    - Os recibos são imprimidos em .txt e guardados na pasta recibos.
    - Os invoices são imprimidos em .pdf para a paste Invoices.