INFRAPROJECT=src/LibraryManager.Infrastructure/LibraryManager.Infrastructure.csproj
WEBPROJECT=src/LibraryManager/LibraryManager.csproj

DB_CONTEXT=LibraryManagerDbContext
RELATIVE_FOLDER_PATH=Controllers

add_migration:
	dotnet ef migrations add $(NAME) --project $(INFRAPROJECT) -s $(WEBPROJECT)
	
remove_migration:
	dotnet ef migrations remove --project $(INFRAPROJECT) -s $(WEBPROJECT)
	
drop_database:
	dotnet ef database drop --project $(INFRAPROJECT) -s $(WEBPROJECT)
	
update_database:
	dotnet ef database update --project $(INFRAPROJECT) -s $(WEBPROJECT)

add_controller:
	dotnet aspnet-codegenerator -p $(WEBPROJECT) controller  -name $(MODEL)sController -m $(MODEL) -dc $(DB_CONTEXT)  --relativeFolderPath $(RELATIVE_FOLDER_PATH) -actions -api 
