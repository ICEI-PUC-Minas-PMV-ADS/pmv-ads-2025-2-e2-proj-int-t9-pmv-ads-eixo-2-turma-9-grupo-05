
# Metodologia

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Documentação de Especificação</a></span>

Antes do início do desenvolvimento, a equipe elaborou a Documentação de Especificação que serviu como base para alinhar os requisitos funcionais e não funcionais, garantindo que todos os membros compreendessem o problema a ser resolvido e os objetivos do projeto. Esse documento orientou a definição da arquitetura, das tecnologias empregadas e dos processos de trabalho adotados.
## Controle de Versão

A ferramenta de controle de versão adotada no projeto foi o
[Git](https://git-scm.com/), sendo que o [Github](https://github.com)
foi utilizado para hospedagem do repositório.

O projeto segue a seguinte convenção para o nome de branches:

- `main`: versão estável já testada do software
- `unstable`: versão já testada do software, porém instável
- `testing`: versão em testes do software
- `dev`: versão de desenvolvimento do software

Quanto à gerência de issues, o projeto adota a seguinte convenção para
etiquetas:

- `documentation`: melhorias ou acréscimos à documentação
- `bug`: uma funcionalidade encontra-se com problemas
- `enhancement`: uma funcionalidade precisa ser melhorada
- `feature`: uma nova funcionalidade precisa ser introduzida

Processo de Versionamento

- `Commits`: devem ser claros e descrever de forma objetiva a modificação realizada.

- `Branches`: cada nova funcionalidade ou correção é desenvolvida em uma branch própria e depois integrada à dev.

- `Merges`: realizados por meio de Pull Requests, revisados por outro membro da equipe antes da integração.

- `Tags`: aplicadas nas versões estáveis para marcação de releases.

## Gerenciamento de Projeto

### Divisão de Papéis

Product Owner (PO): responsável por priorizar as funcionalidades e manter o backlog atualizado.

Scrum Master: garante a aplicação correta da metodologia e auxilia na remoção de impedimentos.

Time de Desenvolvimento: composto pelos demais membros, responsáveis pela implementação, testes e integração contínua.

### Processo

> **O processo adotado foi inspirado no Scrum:**: 
> - O Product Backlog foi criado no GitHub Projects.
> - As tarefas foram divididas em Sprints com duração definida.
> - Foi utilizado um quadro Kanban para monitorar o progresso, com colunas: To Do, In Progress e Done.
> - Reuniões rápidas (checkpoints) foram realizadas para alinhar o andamento das atividades.

Esse fluxo permitiu que a equipe tivesse uma visão clara do andamento do projeto e do status de cada funcionalidade.

### Ferramentas

As principais ferramentas utilizadas no projeto foram:

- Editor de Código: Visual Studio Code – escolhido por sua leveza, ampla documentação, integração nativa com Git e extensões de produtividade.
- Controle de Versão: Git e GitHub – para versionamento e hospedagem do código.
- Comunicação: Discord/WhatsApp – para comunicação rápida, alinhamento de tarefas e compartilhamento de informações.
- Gestão de Projeto: GitHub Projects – usado para organização do backlog, sprints e issues.
- Wireframing/Protótipos: Figma – para elaboração de diagramas de tela e protótipos navegáveis.

A escolha dessas ferramentas se deve à integração entre elas e ao fato de serem amplamente utilizadas no mercado, o que agrega valor acadêmico e profissional ao projeto.
