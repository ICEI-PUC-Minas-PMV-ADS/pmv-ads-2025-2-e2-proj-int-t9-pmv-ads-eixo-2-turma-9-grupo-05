# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas


<img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-2-e2-proj-int-t9-pmv-ads-eixo-2-turma-9-grupo-05/blob/main/src/personas/thomas.jpg" alt="Persona1"/>
<img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-2-e2-proj-int-t9-pmv-ads-eixo-2-turma-9-grupo-05/blob/main/src/personas/carla.jpg" alt="Persona2"/>
<img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-2-e2-proj-int-t9-pmv-ads-eixo-2-turma-9-grupo-05/blob/main/src/personas/luisa.png" alt="Persona3"/>


## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:
| Persona   | Necessidade                                           | Objetivo                                                               |
|-----------|-------------------------------------------------------|-------------------------------------------------------------------------|
| Tomas     | Ter relatórios consolidados de reciclagem automáticos | Garantir transparência e confiança nos resultados apresentados à diretoria e investidores |
| Tomas     | Comparar dados de diferentes unidades                 | Saber quais áreas estão sendo mais eficientes e onde é preciso melhorar |
| Tomas     | Compartilhar dashboards públicos de impacto           | Reforçar a imagem sustentável da empresa e engajar a comunidade |
| Carla     | Acessar métricas confiáveis e consolidadas            | Mostrar o impacto real das ações da ONG e dos parceiros |
| Carla     | Indicar pontos de reciclagem parceiros no mapa        | Engajar a comunidade e facilitar o acesso aos locais de entrega |
| Carla     | Compartilhar resultados em campanhas                  | Ampliar a credibilidade da ONG e atrair mais apoiadores |
| Luísa     | Ver pontos de reciclagem próximos à minha localização | Saber facilmente onde levar meus recicláveis |
| Luísa     | Acompanhar métricas coletivas da cidade               | Sentir que faço parte de um impacto maior na comunidade |
| Luísa     | Saber o que cada ponto aceita                         | Evitar perder tempo indo a locais errados |
## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| O sistema deve coletar automaticamente os dados de pesagem dos materiais em intervalos de tempo pré-definidos  | ALTA | 
|RF-002| O sistema deve enviar os dados de pesagem coletados para o banco de dados Firebase sempre que ocorrer atualização   | ALTA |
|RF-003| A aplicação deve permitir que o usuário visualize um histórico das pesagens registradas | MÉDIA |
|RF-004| A aplicação deve disponibilizar uma página que obtenha a localização atual do usuário (mediante permissão). | ALTA |
|RF-005| A aplicação deve exibir os pontos de reciclagem mais próximos com base na localização do usuário. | ALTA |
|RF-006| A aplicação deve permitir que o usuário filtre os pontos de reciclagem por tipo de material aceito (ex: plástico, vidro, papel, metal). | MÉDIA |
|RF-007| O sistema deve gerar alertas/notificações quando um novo ponto de reciclagem for adicionado próximo à localização do usuário. | BAIXA |
|RF-008| A aplicação deve permitir que o usuário cadastre manualmente um novo ponto de reciclagem, informando dados como endereço, tipo de material aceito e horário de funcionamento. | MÉDIA |
|RF-009| O sistema deve permitir a geração automática de relatórios consolidados de reciclagem em diferentes formatos (PDF, Excel) para facilitar a apresentação dos dados. | Alta |
|RF-010| A aplicação deve disponibilizar métricas coletivas de reciclagem (ex: quantidade total reciclada pela comunidade/cidade). | MÉDIA |
|RF-011| A aplicação deve permitir que o usuário receba notificações sobre campanhas e eventos de reciclagem promovidos por ONGs ou empresas parceiras. | BAIXA |
|RF-012| O sistema deve oferecer ao usuário um guia interativo com informações sobre quais tipos de materiais podem ser reciclados e onde entregá-los. | MÉDIA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RF-001| A aplicação deve ser responsiva e adaptada a diferentes dispositivos (desktop e mobile).  | MÉDIA | 
|RF-002| O sistema deve ter disponibilidade mínima de 99% para garantir acesso contínuo.   | ALTA |
|RF-003| O tempo de resposta para exibir pontos de reciclagem próximos não deve exceder 3 segundos. | ALTA |
|RF-004| O sistema deve armazenar os dados de forma segura no Firebase, garantindo integridade e consistência. | ALTA |
|RF-005| A aplicação deve seguir boas práticas de privacidade ao solicitar e utilizar a localização do usuário. | ALTA |
|RF-006| O sistema deve ser escalável, permitindo aumento no número de usuários e pontos de reciclagem sem perda de desempenho. | MÉDIA |
|RF-007| O sistema deve ter logs de funcionamento para facilitar auditorias e manutenção. | MÉDIA |
|RF-008| A interface deve ser intuitiva, permitindo que usuários sem conhecimento técnico consigam acessar as principais funções. | MÉDIA |
|RF-009| Os relatórios gerados pelo sistema devem manter padronização visual e clareza na apresentação dos dados. | MÉDIA |
|RF-010| O sistema deve ser compatível com diferentes sistemas operacionais móveis (Android e iOS), garantindo acesso pelo celular. | MÉDIA |
|RF-011| A aplicação deve suportar personalização de notificações, permitindo que o usuário escolha quais tipos de alertas deseja receber. | MÉDIA |
|RF-012| O sistema deve garantir acessibilidade, incluindo contraste adequado, textos alternativos e navegação simplificada. | MÉDIA |

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

- [Requisitos Funcionais
 (RF)](https://pt.wikipedia.org/wiki/Requisito_funcional):
 correspondem a uma funcionalidade que deve estar presente na
  plataforma (ex: cadastro de usuário).
- [Requisitos Não Funcionais
  (RNF)](https://pt.wikipedia.org/wiki/Requisito_n%C3%A3o_funcional):
  correspondem a uma característica técnica, seja de usabilidade,
  desempenho, confiabilidade, segurança ou outro (ex: suporte a
  dispositivos iOS e Android).
Lembre-se que cada requisito deve corresponder à uma e somente uma
característica alvo da sua solução. Além disso, certifique-se de que
todos os aspectos capturados nas Histórias de Usuário foram cobertos.

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.
<img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-2-e2-proj-int-t9-pmv-ads-eixo-2-turma-9-grupo-05/blob/main/src/personas/casos_de_uso_fluxograma.png" alt="Diagrama"/>

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
