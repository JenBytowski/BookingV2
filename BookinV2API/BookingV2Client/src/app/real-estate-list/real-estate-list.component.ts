import { Component, OnInit } from '@angular/core';
import { RealEstateService } from '../services/real-estate.service';
import { RealEstateDto } from '../models/real-estate.model';

@Component({
  selector: 'real-estate-list',
  templateUrl: './real-estate-list.component.html',
  styleUrls: ['./real-estate-list.component.css']
})
export class RealEstateListComponent implements OnInit {
  realEstates: RealEstateDto[] = [];
  errorMessages: string[] = [];

  constructor(private realEstateService: RealEstateService) { }

  ngOnInit(): void {
    this.realEstateService.getAll().subscribe({
      next: (data) => {
        this.realEstates = data;
        this.errorMessages = [];
      },
      error: (error) => {
        this.errorMessages = error.message.split(', ');
      }
    });
  }
}
