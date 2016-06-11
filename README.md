# euro2016
Betting for EURO 2016

A learning app using webpack (+loaders), angular, angular-ui-router (loading states on demand), angular material, oclazyload.
On the server side: ASP.NET Core RC2, Entity Framework Core RC2, Windows Authentication, onion architecture.

##To do##
Client side
- [x] **!!! split the existing controller for home page so that it will not be invoked for navigation AND for the home state !!!**
- [x] implement place (now it's #123)
- [ ] template for showing the match
- [ ] webpack bundling for production
- [ ] top must implement md virtual scroll
- [x] top must look nicer
- [ ] html 5 for states
- [ ] make webpack load the bundles when needed (with oclazyload)
- [ ] ...

Server side
- [x] service for stealing the classification from official EURO 2016 site for specified Group
- [ ] connection string should be in config
- [ ] Clean up View Models
- [ ] When EF Core is ready: split the architecture in several projects
- [x] **!!!UserViewService and HomeService contains duplicate code; extract it in IUserService!!!**
- [ ] ...
