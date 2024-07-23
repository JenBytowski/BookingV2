import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RealEstateService } from '../real-estate.service';
import { RealEstateDto } from '../models/real-estate.model';

@Component({
  selector: 'app-real-estate-add',
  //standalone: true,
  //imports: [CommonModule, FormsModule],
  templateUrl: './real-estate-add.component.html',
  styleUrls: ['./real-estate-add.component.css']
})
export class RealEstateAddComponent {
  realEstate: RealEstateDto = { id: 0, address: '', square: 0, roomCount: 0 };

  constructor(private realEstateService: RealEstateService) { }

  addRealEstate(): void {
    this.realEstateService.create(this.realEstate).subscribe(() => {
      alert('Real Estate Added');
      this.realEstate = { id: 0, address: '', square: 0, roomCount: 0 };
    });
  }
}
