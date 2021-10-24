export class UserDataModel {
  constructor(
    public id?: number,
    public username?: string,
    public email?: string,
    public roles: string[] = []
  ) { }
}
