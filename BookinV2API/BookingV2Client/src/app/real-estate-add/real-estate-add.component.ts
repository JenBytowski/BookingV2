import { Component } from '@angular/core';
import { RealEstateService } from '../services/real-estate.service';
import { RealEstateDto } from '../models/real-estate.model';

@Component({
  selector: 'app-real-estate-add',
  templateUrl: './real-estate-add.component.html',
  styleUrls: ['./real-estate-add.component.css']
})
export class RealEstateAddComponent {
  realEstate: RealEstateDto = { id: 0, address: '', square: 0, roomCount: 0 };
  errorMessages: string[] = [];

  constructor(private realEstateService: RealEstateService) { }

  addRealEstate(): void {
    this.realEstateService.create(this.realEstate).subscribe({
      next: (addedRealEstate) => {
        alert('Real Estate Added');
        this.realEstate = { id: addedRealEstate.id, address: addedRealEstate.address, square: addedRealEstate.square, roomCount: addedRealEstate.roomCount };
        this.errorMessages = [];
      },
      error: (error) => {
        this.errorMessages = error.message.split(', ');
      }
    });
  }
}
