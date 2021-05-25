# Metodos de uma consulta SQL com LINQ

## Consulta
- Essa Estrutura tem que ser seguida a risca
- A consulta so é executada quando chama o ToList();
- Podendo ser chamado na variavel ou na consulta
- ( ... ).ToList(); ou query.ToList();
- O retorno dela pode ser List 
- Ou object quando o select retornar um objeto, 
```
    from person in model 
    join address in _context.Addresses
        on person.id equals address.cod_person
    join curso in _context.Cursos
        on person.id equals curso.cod_person into course
    from curso in course.DefaultIfEmpty()
    where address.rua == "Av Mario Werneck" 
        || address.numero == 200
    orderby person.nome descending
    select new {
        person.id,
        person.nome,
        person.genero,
        address.cidade,
        address.bairro,
        address.numero,
        Curso = curso.curso == null 
            ? "Não possui curso superior" 
            : curso.curso
    };
```

## Tabela

- Para a utilização de uma tabela tanto no From como no Join ela ter que possuir sua classe ( Model )
- Para facilitar declare ela na sua classe contexto MySqlContext e utilize ela atravez do _context.Addresses
```
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) {}

        public DbSet<Person> Persons { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Curso> Cursos { get; set; }
    }
```
## From
- Person vai ser o nome da classe model que é a classe da tabela
```
    from person in model
```

## Join
- A tabela que vai dar o join tem que ter uma classe pronta 
- Sempre comece o ON pela coluna da tabela do from (from person)
```
    join address in _context.Addresses 
        on person.id equals address.cod_person
```    
- Join com multiplas colunas ( tabela com chave composta )
```
    join address in _context.Addresses
        on new { person.id , person.field2 } 
    equals new { address.cod_person , address.field2 }
```    

## Left Join
- Caso nao tenha resultado ele pega os valores padrao
```
    join address in _context.Addresses
        on person.id equals address.cod_person into Endereco
    from address in Endereco.DefaultIfEmpty()
```
- Caso não exista voce seta um valor padrao 
```
    select new { 
        person.nome, 
        Address = subaddress?.cidade ?? String.Empty
    };
```

## Where
- Pode ser comparada com qualquer coisa
```
    where person.id == id
```

## And Where
- Do segundo where para frente entra como and
```
    where address.rua == "Av Mario Werneck"
    where address.numero == 1200
```

## Or Where
- Usa o operador " || " que significa or 
- Mesma coisa que uma condicao if
```
    where address.rua == "Av Mario Werneck" || address.numero == 1000
```

## Where In
- declare um array com o mesmo tipo da coluna
- dentro do Contains vai a coluna da tabela
```
    long[] Atencoes = new long[] { 2, 4, 6 };
    where Atencoes.Contains(atencao.cod_atencao)
```

## Where like
- Use o metodo Contains que verifica caracteres dentro de uma string
```
    where inscricao.nome.Contains(nome)
```

## Case
- Utilize if ternario para fazer o Case When Then
```
    Curso = curso.curso == null ? "Não possui curso superior" : curso.curso
```

## Decode
- Mesmo caso do Case acima, porem tem que fazer encadiamento de if ternario

## Execute
- Para executar uma funçao criada no banco ( procedure, function )
```
    var status = _context.Database.ExecuteSqlRaw("EXECUTE dbvestib.inscricao_status_processo");
```

## OrderBy
```
    orderby person.nome descending //ascending
```

## Select
- Para selecionar apenas um objeto completo
```
    select person 
```

- Para selecionar os dois objetos completo
- Nesse caso ele cria mais uma variavel no objeto de retorno
```
    select new { person, address }
    data = {
        person = { ... },
        address = { ... }
    } 
```
- Para selecionar apenas as colunas nescessarias
```
    select new {
        person.id,
        person.nome,
        address.cidade,
        address.bairro 
    }
```
- Para dar um nome customizado aos parametros
```
    select new {
        cod = person.id,
        name = person.nome,
        city = address.cidade,
        neighborhood = address.bairro 
    }
```
- Injecao de variavel no select da consulta
- Para os casos de executar uma função do banco dentro do select, 
```
    string status = "ativo";
    select new {
        person.id,
        person.nome,
        address.bairro,
        address.numero,
        Curso = curso.curso == null 
            ? "Não possui curso superior" 
            : curso.curso,
        status
    }).ToList();
```
- HasMany
```
    select new
    {
        atencao,
        inscricoes = (
            from insc in _context.Inscricoes 
            where insc.cod_atencao == atencao.cod_atencao 
            select insc.nome).ToList()
    }).ToList();
```

# Relacionamentos
## 1 - 1
- Declare uma propriedade com a FK na model que foi criado a FK
```
    public long cod_atencao { get; set; }
```
- Declare qual a propriedade referente a essa chave
```
    [ForeignKey("Atencao")]
```
- Declare uma propriedade do tipo Model da outra tabela
```
    public Atencao Atencao { get; set; }
```
- Resultado final
```
    [ForeignKey("Atencao")]
    public long cod_atencao { get; set; }

    public Atencao Atencao { get; set; }
```

## 1 - N
- Declare uma propriedade com a FK
```
    public long cod_insc { get; set; }
```
- Declare qual a propriedade referente a essa chave
```
    [ForeignKey("Inscricao")]
```
- Declare uma propriedade do tipo Model da outra tabela
- Use List<> ou ICollection<> para indicar que é uma lista
```
    public List<Inscricao> Inscricao { get; set; }
```
- Resultado final
```
    [ForeignKey("Inscricao")]
    public long cod_insc { get; set; }

    public List<Inscricao> Inscricao { get; set; }
```

## N - N
- Declare a FK de cada tabela
```
    public long cod_serie { get; set; }
    public long cod_disciplina { get; set; }
```
- Declare qual a propriedade referente a essa chave
```
    [ForeignKey("Serie")]
    [ForeignKey("Disciplina")]
```
- Declare uma propriedade do tipo Model da outra tabela
- Use List<> ou ICollection<> para indicar que é uma lista
```
    public List<Serie> Serie { get; set; }
    public List<Disciplina> Disciplina { get; set; }
```
- Resultado final
```
    [ForeignKey("Serie")]
    public long cod_serie { get; set; }

    [ForeignKey("Disciplina")]
    public long cod_disciplina { get; set; }

    public List<Serie> Serie { get; set; }
    public List<Disciplina> Disciplina { get; set; }
```
## Observação
- Para usar o relacionamento precisa chamar a propriedade
- Remove o join que iria ser feito
```
    from atencao in _context.Atencoes
    select new {
        atencao.Inscricao
    }
```

# Request

## Query params
- Deve informar o tipo de request aceito, o objeto com as colunas, e a variavel
- [FromQuery] permite enviar parametros pela url
- AlunoDisciplinaRequestGet é uma classe customizada com apénas os campos aceitos
```
    public object Notas([FromQuery] AlunoDisciplinaRequestGet request)
```

## Body
- Pode ou não informar o tipo do request aceito, o objeto com as colunas e a variavel
- O request tem que obedecer as colunas que estão na classe passada
- [FromBody] permite enviar parametros pelo body
- AlunoDisciplinaRequestPost é uma classe customizada com apenas os campos aceitos
```
    public object Post([FromBody] AlunoDisciplinaRequestPost request)
```

## Route
- A sequencia deve ser a mesma passada nos parametros da função
- O nome também tem que ser o mesmo
- Pode passar na rota o tipo aceito
```
    [HttpGet("aluno/{codaluno}/bimestre/{codbimestre}/notas")]
    public object Notas(long codaluno, long codbimestre)
```

## Observação
- Os exemplos foram feitos com uma classe request customizada mas pode ser feito com a propria model
- A vantagem da classe request customizada é poder selecionar apenas o que é preciso
```
    public object Post([FromBody] AlunoDisciplina request)
```