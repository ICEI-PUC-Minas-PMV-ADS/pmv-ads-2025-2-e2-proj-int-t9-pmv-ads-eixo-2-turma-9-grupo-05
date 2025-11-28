# Programação de Funcionalidades (INCLUIR A PROGRAMAÇAÕ DE FUNCIONALIDADE EM PROFUNDIDADE)

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="4-Metodologia.md"> Metodologia</a>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="5-Arquitetura da Solução.md"> Arquitetura da Solução</a>

Nesta seção, a implementação do sistema descrita por meio dos requisitos funcionais e/ou não funcionais. Nesta seção, é essencial relacionar os requisitos atendidos com os artefatos criados (código fonte) e com o(s) responsável(is) pelo desenvolvimento de cada artefato a cada etapa. Nesta seção também deverão ser apresentadas, se necessário, as instruções para acesso e verificação da **implementação que deve estar funcional no ambiente de hospedagem, OBRIGATORIAMENTE, a partir da Etapa 03**.

**O que DEVE ser utilizado para o desenvolvimento da aplicação:**
- Microsoft Visual Studio (IDE de Codificação)
- HTML e CSS (frontend)
- Javascript (frontend)
- C# (backend)
- MySQL ou SQLServer(Base de Dados)
- Bootstrap (template responsivo para frontend)
- Github (documentação e controle de versão)

**O que NÃO PODE ser utilizado:**
- Template React (e qualquer outro template - exceto o Bootstrap)
- Qualquer outra liguagem de programação diferente de C#

A tabela a seguir é um exemplo de como ela deverá ser preenchida considerando os artefatos desenvolvidos.

|ID    | Descrição do Requisito  | Artefatos produzidos | Aluno(a) responsável |
|------|-----------------------------------------|----|----|
|RF-001| O sistema deve permitir que o usuário realize login utilizando email e senha.| UsuarioController.cs • View Login.cshtml • Model Usuario.cs • Validações de autenticação| Alvaro |
|RF-002| O sistema deve permitir o cadastro de novos usuários.     | UsuarioController.cs • View Cadastro.cshtml • Model Usuario.cs • Migration de tabela Usuarios | Alvaro |
|RF-003| O sistema deve permitir o cadastro de Empresas responsáveis pela gestão de resíduos. | EmpresaController.cs • View CadastroEmpresa.cshtml • Model Empresa.cs • Migration de tabela Empresas | Diogo |
|RF-004| O sistema deve permitir o cadastro de Pontos de Coleta com nome, tipo de resíduo, endereço e horário. | PontoColetaController.cs • View CadastroPonto.cshtml • Model PontoColeta.cs • Migration PontosColeta | Diogo |
|RF-005| O sistema deve registrar uma Coleta com data, quantidade e tipo de resíduo. | ColetaController.cs • View CadastroColeta.cshtml • Model Coleta.cs • Migration Coletas | Diogo |
|RF-006| O sistema deve registrar uma Pesagem associada a uma Coleta. | PesagemController.cs • View CadastroPesagem.cshtml • Model Pesagem.cs • Migration Pesagens | Diogo |
|RF-007| O sistema deve listar todas as coletas registradas e exibir detalhes. | ColetaController.cs • View ListarColetas.cshtml • Queries em ColetaRepository | Diogo |
|RF-008| O sistema deve permitir classificar resíduos informando tipo e quantidade. | ResiduoController.cs • View CadastroResiduo.cshtml • Model Residuo.cs • Migration Residuos | Diogo |
|RF-009| O sistema deve permitir consultar todos os pontos de coleta cadastrados. | PontoColetaController.cs • View ListarPontos.cshtml • Query no DB | Diogo |
|RF-010| O sistema deve validar automaticamente quantidades e tipos de resíduos. | Anotações DataAnnotations • Serviços de validação | Diogo |
|RF-011| O sistema deve armazenar dados no banco SQL Server. | Configuração do appsettings.json • EF Core Migrations | Alvaro, Diogo, Gabriel |
|RF-012| A aplicação deve permitir o cadastro de empresas de reciclagem informando nome, CNPJ, email, telefone e endereço. | EmpresaController.cs • View CadastroEmpresa.cshtml • Model Empresa.cs • Migration Empresas | Gabriel |
|RF-013| A aplicação deve permitir listar todas as empresas cadastradas. | mpresaController.cs • View ListarEmpresas.cshtml • Método GetAll() • Query EF Core | Gabriel |
|RF-014| A aplicação deve permitir editar os dados de uma empresa cadastrada. | EmpresaController.cs • View EditarEmpresa.cshtml • Update via EF Core  | Gabriel |
|RF-015| A aplicação deve permitir excluir empresas cadastradas. | EmpresaController.cs • Botão excluir em ListarEmpresas.cshtml • Método Delete() | Gabriel |
|RF-016| O sistema deve manter o histórico e rastreamento das empresas de reciclagem da região. | Regras em EmpresaService.cs • Relacionamentos (Empresa → Coleta/Pesagem) | Gabriel |


# Instruções de acesso

Link: https://ecotrash-rg-h8fhhcb7dahwgja2.brazilsouth-01.azurewebsites.net
