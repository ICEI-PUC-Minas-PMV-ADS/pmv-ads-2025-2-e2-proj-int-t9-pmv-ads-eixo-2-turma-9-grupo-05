# Plano de Testes de Usabilidade

Os testes de usabilidade permitem avaliar a qualidade da interface com o usuário da aplicação interativa.

Um plano de teste de usabilidade deverá conter: 

## Definição do(s) objetivo(s)

Antes de iniciar os testes, é essencial definir o que se deseja avaliar na usabilidade do sistema. 
Alguns exemplos de objetivos são:
- Verificar se os usuários conseguem registrar corretamente as pesagens de materiais recicláveis e não recicláveis.
- Avaliar a clareza da interface de interação com a API (ex: dashboard, endpoints ou aplicativo front-end conectado).
- Identificar barreiras na navegação, compreensão de mensagens de erro e interação com os dados.
- Avaliar a eficiência no envio, consulta e interpretação dos dados registrados.
- Testar a acessibilidade e facilidade de uso para diferentes perfis de usuários (operadores de coleta, gestores de usina de reciclagem, usuários iniciantes em tecnologia).

## Seleção dos participantes

Para garantir que o teste reflita o uso real do sistema, escolha participantes representativos do público-alvo.

**Critérios para selecionar participantes:**
- Perfis variados (operadores, gestores, iniciantes e avançados).  
- Diferentes níveis de familiaridade com tecnologia.
- Inclusão de pessoas com necessidades especiais (se aplicável). 

**Quantidade recomendada:**
Mínimo: 5 participantes.
Ideal: Entre 8 e 12 para maior diversidade.

## Cenários de Teste

**Cenário 1 – Registro de Pesagem**

**Objetivo:**  Avaliar a facilidade no registro de uma nova pesagem.

**Contexto:** O operador precisa registrar 30kg de plástico coletado em um bairro. 

**Tarefa(s):** 
- Acessar a interface da API/aplicação.
- Localizar a opção de **inserir pesagem**.  
- Preencher os dados: material = plástico, peso = 30kg, local = Bairro X.
- Enviar o registro.
  
**Critério(s) de Sucesso(s):**
- Registro aceito e confirmado pelo sistema em até 2 minutos.  
- Usuário compreende as mensagens de feedback.

  
---

**Cenário 2 – Classificação de Materiais**

- **Objetivo:** Avaliar se a interface diferencia corretamente recicláveis e não recicláveis.
    
- **Contexto:** O operador registra duas pesagens: 15kg de vidro reciclável e 20kg de restos orgânicos.
    
- **Tarefas:**  
  1. Inserir a primeira pesagem (vidro reciclável).  
  2. Inserir a segunda pesagem (orgânicos).  
  3. Verificar a classificação do sistema.
     
- **Critérios de Sucesso:**  
  - Sistema classifica corretamente cada pesagem.  
  - Usuário entende a diferença entre categorias.  

---

**Cenário 3 – Consulta de Relatórios**

- **Objetivo:** Avaliar a clareza e rapidez na consulta de relatórios.
  
- **Contexto:** O gestor precisa ver o total de recicláveis coletados na última semana.
  
- **Tarefas:**  
  1. Acessar o painel de relatórios.  
  2. Selecionar o filtro de período (última semana).  
  3. Visualizar os resultados.
     
- **Critérios de Sucesso:**  
  - Relatório exibido em até 30s.  
  - Usuário compreende gráficos e tabelas sem ajuda.  

---

**Cenário 4 – Tratamento de Erros**

- **Objetivo:** Avaliar a experiência diante de erros de entrada.
  
- **Contexto:** O operador tenta inserir uma pesagem sem preencher o campo “peso”.
  
- **Tarefas:**  
  1. Acessar cadastro de pesagem.  
  2. Preencher material, mas deixar peso em branco.  
  3. Enviar o registro.
     
- **Critérios de Sucesso:**  
  - Sistema alerta que o campo é obrigatório.  
  - Usuário corrige sem assistência externa.  

---

**Cenário 5 – Acessibilidade para Iniciantes**

- **Objetivo:** Avaliar se iniciantes conseguem concluir tarefas.
   
- **Contexto:** Um novo operador precisa registrar uma pesagem de 10kg de papel reciclável.
  
- **Tarefas:**  
  1. Entrar no sistema.  
  2. Localizar a opção de cadastro.  
  3. Registrar a pesagem de 10kg de papel.
     
- **Critérios de Sucesso:**  
  - Usuário completa a tarefa em até 5 minutos.  
  - Não solicita ajuda externa.  

---


## Métodos de coleta de dados

Os métodos de coleta serão aplicados durante os testes de usabilidade da API e/ou dashboard conectado.  
O objetivo é compreender **como os usuários interagem com o sistema**, identificar dificuldades e medir a eficiência no uso.

###  Observação Direta
- Monitorar a execução das tarefas em tempo real.  
- Registrar comportamentos, hesitações e momentos de dúvida do usuário.  

###  Métricas Quantitativas
-  Tempo gasto para cada tarefa (ex: registrar pesagem, consultar relatório).  
-  Número de cliques até a conclusão.  
-  Quantidade de erros (ex: tentativa de envio com campo obrigatório vazio).  
-  Número de vezes que o usuário precisou repetir uma ação.  

###  Métricas Qualitativas
- Comentários espontâneos dos participantes.  
- Dificuldades percebidas durante a navegação ou no entendimento das mensagens do sistema.  
- Grau de clareza das classificações (reciclável x não reciclável).  

###  Questionário Pós-Teste
Após a execução, cada participante responderá perguntas como:  
- A interface foi fácil de entender?  
- Você encontrou dificuldades em alguma etapa do registro ou consulta?  
- O feedback do sistema (mensagens de erro, confirmações) foi claro?  
- O que poderia ser melhorado para facilitar o uso?  

###  Considerações de Privacidade (LGPD)
- Nenhum dado pessoal sensível será coletado.  
- Participantes serão identificados apenas como **Usuário 1, Usuário 2, ...**.  
- As métricas e respostas serão apresentadas de forma **anônima e agregada**, sem expor a identidade de ninguém.  
