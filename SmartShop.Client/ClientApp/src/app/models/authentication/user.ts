

export class User {
  constructor(
    public userName?: string,
    public accessToken?: string,
    public role?: string[],
    public tokenExipres?: Date,
    public refreshToken?: string
  ) { }
}
