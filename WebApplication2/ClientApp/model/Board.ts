import { Task } from './Task';

export interface Board
{
    Id : string,
    Name: string,
    Items: Task[]
}