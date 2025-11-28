# Registro de Testes de Software

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>, <a href="8-Plano de Testes de Software.md"> Plano de Testes de Software</a>

Para cada caso de teste definido no Plano de Testes de Software, realize o registro das evidências dos testes feitos na aplicação pela equipe, que comprovem que o critério de êxito foi alcançado (ou não!!!). Para isso, utilize uma ferramenta de captura de tela que mostre cada um dos casos de teste definidos (obs.: cada caso de teste deverá possuir um vídeo do tipo _screencast_ para caracterizar uma evidência do referido caso).

| **Caso de Teste** 	|**CT01 – Cadastro de Pesagem**|
|:---:	|:---:	|
|	Requisito Associado 	| RF-01 O sistema deve coletar automaticamente os dados de pesagem dos materiais em intervalos de tempo pré-definidos, RF-02 O sistema deve enviar os dados de pesagem coletados para o banco de dados SQL sempre que ocorrer atualização    |
| Registro de Evidência | https://drive.google.com/file/d/1Hhih0y2f04nRiMia_DehrrH6w4N27mUZ/view?usp=sharing |
| **Caso de Teste** 	|**CT02 – Histórico de Pesagem**|
|:---:	|:---:	|
|	Requisito Associado 	| RF-03 A aplicação deve permitir que o usuário visualize um histórico das pesagens registradas |
| Registro de Evidência | https://drive.google.com/file/d/1Hhih0y2f04nRiMia_DehrrH6w4N27mUZ/view?usp=sharing |
| **Caso de Teste** 	| **CT03 – Cadastro de Empresas** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-04 A aplicação deve disponibilizar cadastro de empresas e novos usuarios. |
| Registro de Evidência | https://drive.google.com/file/d/1uY44KK67cHu-DuuUuxOcF3x3ooSS00Dk/view?usp=sharing |
| **Caso de Teste** 	| **CT04 – Ponto de Coleta ** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-005 A aplicaçao deve disponibilizar a exclusão de um ponto de coleta, RF-011 A aplicação deve mostar no maps para o usuario o ponto de coleta escolhido|
| Registro de Evidência | https://drive.google.com/file/d/1bg7fYPIauFwNURBSazd9qRWyCCJvqzsg/view?usp=sharing |
| **Caso de Teste** 	| **CT05 – Filtragem de Matérial** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-06 A aplicação deve permitir que o usuário filtre os pontos de reciclagem por tipo de material aceito (ex: plástico, vidro, papel, metal) |
| Registro de Evidência | N/A |
| **Caso de Teste** 	| **CT06 – Cadastro de Usuario** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-04 A aplicação deve disponibilizar cadastro de empresas e novos usuarios. |
| Registro de Evidência | https://drive.google.com/file/d/1uY44KK67cHu-DuuUuxOcF3x3ooSS00Dk/view?usp=sharing |
| **Caso de Teste** 	| **CT07 – Detalhes da Empresa** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-07 A aplicação deve disponibilizar detalhes da empresas cadastradas  |
| Registro de Evidência | https://drive.google.com/file/d/1uY44KK67cHu-DuuUuxOcF3x3ooSS00Dk/view?usp=sharing |
| **Caso de Teste** 	| **CT08 –Cadastro de locais de coleta pelos usuarios** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-08 A aplicação deve permitir que o usuário cadastre manualmente um novo ponto de reciclagem, informando dados como endereço, tipo de material aceito e horário de funcionamento. |
| Registro de Evidência | https://drive.google.com/file/d/1bg7fYPIauFwNURBSazd9qRWyCCJvqzsg/view?usp=sharing |
| **Caso de Teste** 	| **CT09 –Relatórios de Coleta** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-09 O sistema deve permitir a geração automática de relatórios consolidados de reciclagem em diferentes formatos (PDF, Excel) para facilitar a apresentação dos dados. |
| Registro de Evidência | N/A |
| **Caso de Teste** 	| **CT10 –Notificação** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-012 A aplicação deve notificar o usuario quando um ponto de coleta novo é atribuido  |
| Registro de Evidência | N/A |


## Relatório de testes de software

Os testes de software realizados tiveram como objetivo validar o funcionamento das principais funcionalidades do sistema de gerenciamento de reciclagem, avaliando desempenho, usabilidade, consistência dos dados e aderência aos requisitos funcionais. A partir dos testes, foi possível identificar tanto pontos fortes quanto fragilidades importantes para a evolução do projeto.

## 1. Resultados Gerais dos Testes 

De forma geral, as funcionalidades já implementadas — como cadastro de empresas, cadastro de locais, cadastro de pesagens, histórico e exportação simples — apresentaram estabilidade no ambiente local. Entretanto, após a hospedagem no Azure, alguns comportamentos divergentes foram observados, impactando diretamente a execução e validação de alguns requisitos.

Pontos fortes identificados

Estabilidade em ambiente local: As funções principais funcionaram corretamente durante a fase de desenvolvimento.

Interface simples e intuitiva: Fluxos de navegação claros, permitindo operação sem dificuldade.

Processos de cadastro funcionando corretamente: Empresas, locais e pesagens foram registrados sem falhas.

Exportação básica operante: Ainda limitada, mas funcional antes do deploy.

Esses fatores evidenciam que a base do projeto está funcional e consistente no ambiente de desenvolvimento.

## 2. Fragilidades identificadas (após a hospedagem no Azure) 

Durante os testes no ambiente publicado, diversas funcionalidades previstas em requisitos não estavam disponíveis ou deixaram de funcionar conforme planejado. As falhas registradas estão diretamente relacionadas aos requisitos RF-09, RF-12 e RF-06.

Importante destacar que parte dessas falhas ocorreram apenas após a hospedagem no Azure, sugerindo incompatibilidades, arquivos ausentes ou configurações incorretas no ambiente de produção.

**- Falha no RF-09 – Relatórios Consolidados (PDF/Excel)**

Resultado do teste: Falha total
Motivo: A funcionalidade não foi implementada completamente, e após o deploy no Azure a rotina de exportação deixou de funcionar.
Impacto:

Relatórios consolidados não podem ser gerados.

Usuário depende apenas da visualização básica na interface.

Dificulta análises e apresentação dos dados.

**- Falha no RF-12 – Notificação de Novos Pontos de Coleta**

Resultado do teste: Falha total
Motivo: O sistema não possui mecanismo de notificação configurado e, no Azure, scripts e serviços configuráveis não foram carregados.
Impacto:

Usuários não são alertados sobre novas atribuições.

Fluxo de comunicação é prejudicado.

**- Falha no RF-06 – Filtro de Materiais por Tipo**

Resultado do teste: Falha total
Motivo: A filtragem não foi implementada na interface, e as rotas esperadas no back-end não estavam operacionais no ambiente hospedado.
Impacto:

Usuários não conseguem refinar os pontos de coleta por material.

Experiência prejudicada, diminuindo a eficiência do sistema.

## 3. Evidências das Falhas 

As evidências registradas mostram que:

CT09 – Relatórios de Coleta: Não exibiu botões ou funções no ambiente hospedado.

CT10 – Notificação: Nenhum sistema de alerta foi carregado pelo Azure.

CT05 – Filtragem por Material: Campos de filtro não aparecem no deploy, apesar de testes locais em protótipo.

Esses registros reforçam que as falhas ocorreram principalmente no ambiente de hospedagem, não somente no desenvolvimento.

## 4. Estratégias de Correção e Melhorias Futuras 
Ações para corrigir problemas causados no Azure

Revisar connection strings, permissões e APIs desabilitadas.

Reconfigurar serviços que não foram iniciados (notificações, geração de arquivos).

Verificar compatibilidade do .NET e dependências na hospedagem.

Ajustar paths relativos/absolutos usados em exportações de PDF e Excel.

**Correção dos requisitos pendentes**
RF-09 – Relatórios

Implementar com iTextSharp (PDF) e EPPlus (Excel).

Criar endpoint público para exportação.

RF-12 – Notificações

Integrar SignalR ou SendGrid do Azure.

RF-06 – Filtragem

Criar dropdown de materiais.

Implementar query e atualização da interface.

## 5. Melhoria contínua após os testes 

Com base nas falhas identificadas após a hospedagem, as seguintes ações foram propostas:

Ajustar interface utilizando Bootstrap 5 para responsividade.

Otimizar desempenho das consultas SQL.

Melhorar feedback visual para o usuário.

Implementar logs no Azure para detectar erros automaticamente.

## Conclusão 

Os testes demonstram que o sistema possui uma boa estrutura funcional, porém algumas funcionalidades deixaram de operar corretamente após a hospedagem no Azure, influenciando diretamente a validação dos requisitos RF-09, RF-12 e RF-06.

A análise dos testes permitiu identificar falhas críticas, seus impactos e definir estratégias para correções e melhorias na próxima versão do sistema.
