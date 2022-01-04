# What is FastCQRS?
FastCQRS is a lightweight and easy to use support class and interfaces for implementing [CQRS (Command Query Responsibility Segregation)](https://en.wikipedia.org/wiki/Command%E2%80%93query_separation#Command_query_responsibility_separation).
# How do I use it?
Let's create a simple login use case where there is a LoginService and a LoginModel class. The LoginService class will receive an username and password, performs any work necessary and return true if username and password is valid, otherwise, false. The LoginModel is just a simple class to hold the data of the user trying to log in.

```csharp
public sealed class LoginService {

    public bool LogUser(string username, string verySecurePassword){
        //check users table, perform many validations...
        return true;
    }
}

public sealed class LoginModel {

    public string Username { get; set; }
    public string Password { get; set; }

}
```

Chances are very likely (but not restricted to) you're working on a .NET MVC Controller or API Controller and:
1. you have an instance of LoginService injected by [dependecy injection](https://en.wikipedia.org/wiki/Dependency_injection) into your controller
2. you have a method which receives a LoginModel instance which you will use to call LogUser in the injected service. Am I right? No? That's ok.

Well, what we want is to disconnect the [Domain/Business](https://en.wikipedia.org/wiki/Domain-driven_design) part of the application from the "MVC/HTTP/Web API/REST" part of the application.

To accomplish that:

1. Create a ```LoginCommand``` class inheriting from ```Command```. The IDE will ask you to implement the interface.

2. Create ```LoginHandler``` class inheriting from ```HandlerBase``` and ```IHandler<LoginCommand>```. The IDE will, again, ask you to implement the interface.

Our LoginCommand will looks like this:
```csharp
public class LoginCommand : Command
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public override void Validate()
        {
            //Todo: perform a proper validation on username and password

            if (string.IsNullOrEmpty(Username))
            {
                AddNotification(new Notification(nameof(Username), "Username is invalid."));
            }
        }
    }
```

And our LoginHandler will look like this:
```csharp
public class LoginHandler : HandlerBase, IHandler<LoginCommand>
    {
        private readonly LoginService service;

        public LoginHandler(LoginService _service)
        {
            service = _service;
        }

        public Task<ICommandResult> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            return base.Handle(command, () =>
            {
                return service.LogUser(command.Username, command.Password);
            });
        }
    }
```

Notice that the method ```base.Handle``` receives an anonymous function which returns a ```Task``` from LoginService. The class ```HandlerBase``` will call the ```Validate``` method in the ```Command``` and if there are no errors the command will be executed. Whatever data your service returns will be stored in the data property of the ```CommandResult``` object returned by the ```HandlerBase```.

Notice too that our ```LoginHandler``` receives a ```LoginService``` instance by [dependency injection](https://en.wikipedia.org/wiki/Dependency_injection).

Now you have to check ```CommandResult.Success``` returned by ```base.Handle``` in order to know if the command was succeeded.

In short, all you need to do is:
1. Implement a YourCommand class.
2. Implement a YourHandler class.
3. Write a validation (if necessary) in YourCommand class.
4. Call base.Handle in YourHandler class.

Said that, now your controllers must be injected with the required handlers and your controller methods must receive an instance of the required Commands or you can instantiate commands inside your controller (not recommended).

That's all.

I hope you enjoy it! Feel free to ask any questions or suggest any improvements.

