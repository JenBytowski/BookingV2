import { Component, OnInit } from '@angular/core';
import { RealEstateService } from '../real-estate.service';
import { RealEstateDto } from '../models/real-estate.model';

@Component({
  selector: 'real-estate-list',
  templateUrl: './real-estate-list.component.html',
  styleUrls: ['./real-estate-list.component.css']
})
export class RealEstateListComponent implements OnInit {
  realEstates: RealEstateDto[] = [];

  constructor(private realEstateService: RealEstateService) { }

  ngOnInit(): void {
    this.realEstateService.getAll().subscribe(data => {
      this.realEstates = data;
    });
  }
}
