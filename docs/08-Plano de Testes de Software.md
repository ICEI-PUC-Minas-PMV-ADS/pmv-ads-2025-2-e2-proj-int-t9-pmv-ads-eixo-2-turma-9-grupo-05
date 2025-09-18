# Plano de Testes de Software

| **Caso de Teste** 	| **CT01 – Coletar dados de pesagem** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-001 - O sistema deve coletar automaticamente os dados de pesagem dos materiais em intervalos pré-definidos. |
| Objetivo do Teste 	| Verificar se a coleta automática dos dados de pesagem ocorre conforme esperado. |
| Passos 	| - Ativar o sistema de coleta <br> - Aguardar o intervalo de tempo definido <br> - Verificar se os dados da balança foram coletados e armazenados temporariamente |
| Critério de Êxito | - Os dados de pesagem são registrados automaticamente no sistema sem necessidade de intervenção manual. |
|  	|  	|

| **Caso de Teste** 	| **CT02 – Enviar dados para o banco de dados** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-002 - O sistema deve enviar os dados de pesagem coletados para o banco de dados sql sempre que ocorrer atualização. |
| Objetivo do Teste 	| Garantir que os dados coletados sejam enviados corretamente para o banco de dados. |
| Passos 	| - Realizar uma coleta de pesagem <br> - Confirmar o envio automático para o banco de dados <br> - Acessar o banco de dados e verificar se os dados foram registrados |
| Critério de Êxito | - Os dados aparecem corretamente no banco de dados após cada coleta |
|  	|  	|

| **Caso de Teste** 	| **CT03 – Visualizar dados no painel web** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-003 - A aplicação deve permitir que o usuário visualize as informações coletadas no painel. |
| Objetivo do Teste 	| Verificar se os dados armazenados são exibidos corretamente na interface. |
| Passos 	| - Acessar a aplicação web pelo navegador <br> - Fazer login no sistema (se houver autenticação) <br> - Navegar até o painel de visualização <br> - Conferir se os dados da última coleta aparecem corretamente |
| Critério de Êxito | - O painel exibe os dados atualizados de forma correta e legível |
|  	|  	|

| **Caso de Teste** 	| **CT04 – Cadastrar usuário** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-004 - A aplicação deve permitir o cadastro de usuários para acesso ao sistema. |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar o cadastro corretamente. |
| Passos 	| - Acessar a aplicação web <br> - Clicar em "Cadastrar" <br> - Preencher os campos obrigatórios (nome, e-mail, senha) <br> - Confirmar o cadastro |
| Critério de Êxito | - O sistema exibe mensagem de sucesso e o usuário passa a constar no banco de dados. |
|  	|  	|

| **Caso de Teste** 	| **CT05 – Login de usuário** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-005 - A aplicação deve permitir login de usuários cadastrados. |
| Objetivo do Teste 	| Verificar se o usuário consegue acessar o sistema com suas credenciais. |
| Passos 	| - Acessar a aplicação web <br> - Clicar em "Entrar" <br> - Informar e-mail e senha previamente cadastrados <br> - Confirmar login |
| Critério de Êxito | - O sistema autentica o usuário e redireciona para o painel principal. |
|  	|  	|

| **Caso de Teste** 	| **CT06 – Gerar relatório de coletas** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-006 - O sistema deve gerar relatórios com o histórico das coletas realizadas. |
| Objetivo do Teste 	| Verificar se o sistema gera corretamente um relatório com as informações das coletas armazenadas. |
| Passos 	| - Acessar a aplicação web <br> - Fazer login no sistema <br> - Navegar até a seção de relatórios <br> - Selecionar período de coleta <br> - Gerar relatório |
| Critério de Êxito | - O sistema exibe/baixa um relatório contendo os dados corretos de acordo com o período selecionado. |
|  	|  	|

| **Caso de Teste** 	| **CT07 – Login inválido** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-005 - A aplicação deve permitir login de usuários cadastrados. |
| Objetivo do Teste 	| Garantir que o sistema bloqueia tentativas de login com credenciais inválidas. |
| Passos 	| - Acessar a aplicação web <br> - Clicar em "Entrar" <br> - Informar e-mail inexistente ou senha incorreta <br> - Confirmar login |
| Critério de Êxito | - O sistema exibe mensagem de erro e não permite o acesso. |
|  	|  	|

| **Caso de Teste** 	| **CT08 – Cadastro com dados incompletos** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-004 - A aplicação deve permitir o cadastro de usuários para acesso ao sistema. |
| Objetivo do Teste 	| Garantir que o sistema não permita cadastro com campos obrigatórios em branco. |
| Passos 	| - Acessar a aplicação web <br> - Clicar em "Cadastrar" <br> - Preencher parcialmente os dados (ex: sem e-mail ou senha) <br> - Confirmar cadastro |
| Critério de Êxito | - O sistema exibe mensagem de erro solicitando o preenchimento dos campos obrigatórios. |
|  	|  	|

| **Caso de Teste** 	| **CT09 – Falha no envio para o banco de dados** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-002 - O sistema deve enviar os dados de pesagem coletados para o banco de dados Firebase sempre que ocorrer atualização. |
| Objetivo do Teste 	| Garantir que o sistema trata corretamente falhas de conexão com o banco de dados. |
| Passos 	| - Desconectar a aplicação da internet <br> - Realizar uma coleta de pesagem <br> - Verificar a resposta do sistema |
| Critério de Êxito | - O sistema exibe mensagem de erro e tenta reenviar os dados quando a conexão for restabelecida. |
|  	|  	|

| **Caso de Teste** 	| **CT10 – Performance na coleta de dados** 	|
|:---:	|:---:	|
| Requisito Associado 	| RNF-001 - O sistema deve responder às operações de coleta e envio de dados em até 2 segundos. |
| Objetivo do Teste 	| Validar o desempenho do sistema em condições normais de uso. |
| Passos 	| - Ativar o sistema de coleta <br> - Monitorar o tempo de resposta entre a coleta e o registro no banco de dados <br> - Repetir o processo em diferentes horários |
| Critério de Êxito | - O tempo de resposta não ultrapassa 2 segundos em 95% dos testes realizados. |
|  	|  	|
| **Caso de Teste** 	| **CT11 – Segurança de acesso aos dados** 	|
|:---:	|:---:	|
| Requisito Associado 	| RNF-002 - O sistema deve garantir que apenas usuários autenticados tenham acesso às informações de pesagem. |
| Objetivo do Teste 	| Verificar se os dados só podem ser acessados após autenticação válida. |
| Passos 	| - Acessar a aplicação web sem estar logado <br> - Tentar acessar diretamente a URL do painel ou relatório <br> - Observar a resposta do sistema |
| Critério de Êxito | - O sistema bloqueia o acesso e redireciona para a tela de login. |
|  	|  	|

| **Caso de Teste** 	| **CT12 – Usabilidade da interface** 	|
|:---:	|:---:	|
| Requisito Associado 	| RNF-003 - A aplicação deve apresentar interface intuitiva e de fácil navegação. |
| Objetivo do Teste 	| Validar a facilidade de uso do sistema pelos usuários finais. |
| Passos 	| - Acessar a aplicação web <br> - Navegar pelas principais funcionalidades (coleta, visualização, relatórios) <br> - Observar clareza dos menus, botões e mensagens exibidas |
| Critério de Êxito | - O usuário consegue realizar as tarefas sem dificuldades e sem precisar de treinamento prévio. |
|  	|  	|


