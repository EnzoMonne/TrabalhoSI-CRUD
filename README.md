# Fundamentos de Sistema de Informação

## Nome:
- Enzo Monnerat Martins Bravo Marquet
- Bernardo Castro Barros
- Juan Fagundes Knupp

## Projeto: Sistema Imobiliário

### O que?
O projeto desenvolvido foi um **sistema imobiliário** composto por três classes principais:
- `Client` (Cliente)
- `Property` (Propriedade)
- `Contract` (Contrato)

### Como?
O sistema foi desenvolvido utilizando a linguagem de programação **C#** com o framework **ASP.NET** (versão .NET 8). A interface foi criada com **Razor Pages**, permitindo a interação entre o front-end e o back-end de maneira simplificada.

#### Armazenamento de Dados
Em vez de utilizar um banco de dados tradicional, criamos uma classe `FakeDbContext`, localizada na pasta **Data**, que contém três listas para armazenar os dados das três classes principais (`Client`, `Property` e `Contract`).

#### ViewModels
Para integrar o front-end com o back-end, usamos **ViewModels** para transportar os dados do `FakeDbContext` para as páginas correspondentes. Esses ViewModels conectam a interface com os dados processados no back-end.

#### Arquitetura
Adotamos a arquitetura **MVC (Model-View-Controller)**:
- **Model**: Responsável pelas classes principais.
- **View**: Interface do usuário.
- **Controller**: Gerencia a interação entre o back-end e o front-end.

---

## Fluxo de Dados de Cada Tela

### Home
1. **Index**  
   - Entrada: Nenhuma
   - Saída:  
     - `Client`: Id, FullName, Email  
     - `Property`: Id, Address, Price  
     - `Contract`: Id, ClientId, PropertyId, ContractDate
![image](https://github.com/user-attachments/assets/aa801597-022f-4f43-b990-261c6289c59a)

### Client
1. **Create**  
   - Entrada: FirstName, LastName, Email  
   - Saída: Visualização com o novo cliente na lista  
![image](https://github.com/user-attachments/assets/1f64a246-5feb-46b2-8a0c-603603487f72)

2. **Delete**  
   - Entrada: ID do cliente  
   - Saída: Visualização sem o cliente na lista (retirada de um cliente da lista e o fechamento daquele contrato relacinado, caso tenha um.)
![image](https://github.com/user-attachments/assets/16545309-83db-424d-ac39-8d149a996f31)

3. **Edit**  
   - Entrada: ID do cliente  
   - Saída: Visualização dos detalhes do cliente atualizados
![image](https://github.com/user-attachments/assets/ecf6e1a9-12b3-4e77-a327-ca391fcc104d)

4. **Details**  
   - Entrada: ID do cliente  
   - Saída: Visualização completa dos dados do cliente, propriedades e contratos  
![image](https://github.com/user-attachments/assets/9c19918e-8305-43e9-8fed-9e2818ba8aa1)

5. **LinkProperty**  
   - Entrada: ID do cliente, Lista das Propriedades  
   - Saída: Visualização dos detalhes do cliente com nova propriedade vinculada (e criacao de um contrato)
![image](https://github.com/user-attachments/assets/d50d1ca4-a0ff-41fa-99e3-faaae2beec63)

### Property
1. **Create**  
   - Entrada: Address, Price  
   - Saída:Visualização com o nova propriedade na lista
![image](https://github.com/user-attachments/assets/5985c417-430e-4410-a5e2-3a7337c383bc)

2. **Delete**  
   - Entrada: ID da propriedade  
   - Saída: Visualização sem a propriedade na lista (fechamento de seu contrato relacinado, caso tenha um.)
![image](https://github.com/user-attachments/assets/900ee2cd-bc59-45aa-8a34-2767b1c2c1e0)

3. **Edit**  
   - Entrada: ID da propriedade  
   - Saída: Visualização dos detalhes da propriedade atualizados
![image](https://github.com/user-attachments/assets/331c0f0e-d91f-4252-b3be-8b5026aaeb77)

4. **Details**  
   - Entrada: ID da propriedade  
   - Saída: Visualização completa dos dados da propriedade e contratos relacionados  
![image](https://github.com/user-attachments/assets/69055a31-d3ac-416e-85a3-284b56d40a76)

### Contract
1. **Create**  
   - Um contrato pode ser criado a partir dos detalhes do cliente usando o Link Property (Vincular propriedade)
![image](https://github.com/user-attachments/assets/6c8f3658-cb49-46a4-a170-7c886bfa2cee)

2. **Delete**  
   - Entrada: ID do contrato  
   - Saída: Visualização sem o contrato na lista (Desvincularização da propriedade e o cliente de mesmo contrato)
![image](https://github.com/user-attachments/assets/6dc25535-489f-47cb-95b3-714033654a17)

3. **Edit**  
   - Entrada: ID do contrato  
   - Saída: Visualização dos detalhes do contrato atualizados
![image](https://github.com/user-attachments/assets/22c91101-04ab-4af1-94dc-1649ae40bcad)

4. **Details**  
   - Entrada: --  
   - Saída: Visualização completa dos dados do contrato  
![image](https://github.com/user-attachments/assets/0977d7c9-5215-4587-8c45-dc84d427d5c0)

---

## Testes

### Testes de Unidade
Os testes foram realizados utilizando o framework **xUnit** para garantir o funcionamento correto das classes e funcionalidades isoladas.

#### Testes da Classe `Client`:
- **Criação de Cliente**: Verificação da adição correta do cliente à lista.
- **Edição de Cliente**: Atualização de informações de clientes e validação dos dados atualizados.
- **Exclusão de Cliente**: Remoção de clientes e encerramento de contratos relacionados.
- **Vinculação de Cliente a uma Propriedade**: Teste da criação de contratos entre cliente e propriedade.

#### Testes da Classe `Property`:
- **Criação de Propriedade**: Adição de novas propriedades à lista.
- **Exclusão de Propriedade**: Remoção da propriedade e contratos relacionados.
- **Edição de Propriedade**: Atualização dos dados da propriedade.

#### Testes da Classe `Contract`:
- **Criação de Contrato**: Validação da criação de contratos entre clientes e propriedades.
- **Exclusão de Contrato**: Remoção de contratos e desvinculação entre cliente e propriedade.
- **Edição de Contrato**: Atualização do estado do contrato (aberto/fechado).

### Testes de Integração
Os testes de integração garantiram o correto funcionamento entre as diferentes camadas do sistema, validando o fluxo de dados entre o back-end e o front-end.

### Testes Funcionais
Os testes funcionais simularam o comportamento do usuário no sistema, verificando operações como:
- Criação de clientes
- Atualização de propriedades
- Exibição correta dos dados nas telas de detalhes

---

