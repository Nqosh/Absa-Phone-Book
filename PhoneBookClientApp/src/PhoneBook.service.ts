import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from './environments/environment';
import { CreateContact } from './phonebook/createcontact';
import { Phonebook } from './phonebook/phonebook';

@Injectable({
  providedIn: 'root'
})
export class PhoneBookService {

  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) {
  console.log(this.baseUrl + 'api/PhoneBook/Get');
}

getPhoneBook() {

  return  this.http.get<Phonebook[]>(this.baseUrl + 'api/PhoneBook');
}

saveContact(contact: CreateContact) {
 return this.http.post(this.baseUrl + 'api/PhoneBook', contact);
}

}
