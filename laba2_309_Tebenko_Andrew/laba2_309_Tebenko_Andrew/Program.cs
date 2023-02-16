using NLog; //NLog library
using UnitConversion; // UnitConversion library
using AutoMapper; //AutoMapper library
using RestSharp; //RestSharp library
using FluentValidation; //FluentValidation library


Console.WriteLine("Using the NLog library:");

var logConfig = new NLog.Config.LoggingConfiguration();
logConfig.AddRule(LogLevel.Trace, LogLevel.Fatal, new NLog.Targets.ConsoleTarget("Console"));
LogManager.Configuration = logConfig;
Logger log = LogManager.GetCurrentClassLogger();

log.Fatal("You can see the fatal message");
log.Debug("You can see the debug message");
log.Error(new Exception(), "You can see the error message");

Console.WriteLine("Using the UnitConversion library:");

var gramToKgConverter = new MassConverter("gram", "kg");
double gram = 3000;
double kg = gramToKgConverter.LeftToRight(gram);
Console.WriteLine(gram + " gram = " + kg + " kg");

Console.WriteLine("Using the AutoMapper library:");

var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<PersonInfo, PersonDto>(); });
var mapper = configuration.CreateMapper();
PersonInfo person = new PersonInfo();
person.Fullname = "Andrew Tebenko";
person.Age = 20;
person.Specialisation = "Programmer";
var personDto = mapper.Map<PersonDto>(person);
Console.WriteLine(personDto.Fullname);

Console.WriteLine("Using the RestSharp library:");

var restClient = new RestClient("https://jsonplaceholder.typicode.com/users");
var request = new RestRequest();
Console.WriteLine(restClient.Get<Object>(request));

Console.WriteLine("Using the FluentValidation library:");

PersonValidator personValidator = new PersonValidator();
personValidator.Validate(person);
person.Fullname = "Andrew Tebenko";
var resultFullName = personValidator.Validate(person);
Console.WriteLine(resultFullName);

class PersonInfo
{
    private string fullname;
    private int age;
    private string specialization;

    public string Fullname
    {
        set => fullname = value;
        get => fullname;
    }

    public int Age
    {
        set => age = value;
        get => age;
    }

    public string Specialisation
    {
        set => specialization = value;
        get => specialization;
    }
}

class PersonDto
{
    private string fullname;

    public string Fullname
    {
        get => fullname;
        set => fullname = value;
    }
}

class PersonValidator : AbstractValidator<PersonInfo>
{
    public PersonValidator()
    {
        RuleFor(x => x.Fullname).NotEmpty().WithMessage("Please enter your fullname");
        RuleFor(x => x.Fullname).Length(2, 22);
    }
}