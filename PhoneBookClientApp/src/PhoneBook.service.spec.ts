/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PhoneBookService } from './PhoneBook.service';

describe('Service: PhoneBook', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PhoneBookService]
    });
  });

  it('should ...', inject([PhoneBookService], (service: PhoneBookService) => {
    expect(service).toBeTruthy();
  }));
});
