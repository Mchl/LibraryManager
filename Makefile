PROJECT=src/LibraryManager.Infrastructure/LibraryManager.Infrastructure.csproj
STARTPROJECT=src/LibraryManager/LibraryManager.csproj

add_migration:
	dotnet ef migrations add $(NAME) --project $(PROJECT) -s $(STARTPROJECT)
	
remove_migration:
	dotnet ef migrations remove --project $(PROJECT) -s $(STARTPROJECT)
	
drop_database:
	dotnet ef database drop --project $(PROJECT) -s $(STARTPROJECT)
	
update_database:
	dotnet ef database update --project $(PROJECT) -s $(STARTPROJECT)