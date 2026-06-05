export interface LoginRequest{
    username: string;
    password: string
}

export interface User{
    username : string,
    email : string,
    firstName : string,
    lastName : string,
    roles : string[] 
}