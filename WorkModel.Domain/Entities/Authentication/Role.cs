namespace WorkModel.Domain.Entities.Authentication;

public class Role : EntityBase
{
  public string Name { get; set; }
  //Constructor para EF Core
  public Role() { }
  public Role(string name)
  {
    Name = name;
  }
  //If you want to add logic to change name
  public void UpdateName(string newName)
  {
    Name = newName;
  }
}