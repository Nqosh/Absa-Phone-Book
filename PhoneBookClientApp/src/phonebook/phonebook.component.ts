import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { AlertifyService } from '../alertify.service';
import { NgForm } from '@angular/forms';
import { Phonebook } from './phonebook';
import { environment } from 'src/environments/environment';
import { PhoneBookService } from 'src/PhoneBook.service';
import { CreateContact } from './createcontact';
import { element } from 'protractor';

@Component({
  selector: 'app-phonebook',
  templateUrl: './phonebook.component.html',
  styleUrls: ['./phonebook.component.scss']
})
export class PhonebookComponent implements OnInit {

  @ViewChild('phoneBookfrm', {static: false}) phoneBookfrm: NgForm;

  phonebook: Phonebook[];
  newContact: any = {};
  entryTypes: string[] = new Array('Mobile', 'Work', 'Fax');
  baseUrl = environment.apiUrl;


  constructor(private alertify: AlertifyService, private http: HttpClient, private phoneBookService: PhoneBookService) { }

  ngOnInit() {
    this.getPhoneBook();
  }

  getPhoneBook() {
   this.phoneBookService.getPhoneBook().subscribe(result => {
      this.phonebook = result;
      for (const item of this.phonebook){
        console.log(item);
        for (const entry of item.entries) {
          console.log(entry.entryType);
          console.log(entry.phoneNumber);
        }
      }
    }, error => {
      this.alertify.error(error);
    });

}

    saveContact(contact: CreateContact) {
        if (!this.phoneBookfrm.valid) {
            Object.keys(this.phoneBookfrm.control).forEach(field => {
                const control = this.phoneBookfrm.controls[field];
                control.markAsTouched({ onlySelf: true });
});
            return;
        }
        this.phoneBookService.saveContact(contact).subscribe(result => {
          this.getPhoneBook();
          this.cancelContact();
          this.alertify.success('Contact has been Saved successfully');
        }, error => {
          if (error.status === 409) {
            this.alertify.error('Entry already exists, for this contact');
          }
        });
    }

    cancelContact() {
      this.phoneBookfrm.reset();
      this.newContact = {};
  }

  }



