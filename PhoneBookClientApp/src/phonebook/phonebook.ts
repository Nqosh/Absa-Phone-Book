import { Entry } from './entry';

export interface Phonebook {
    id: number;
    name: string;
    entries: Entry[];
}
