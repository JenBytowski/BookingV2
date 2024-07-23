import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map, of } from 'rxjs';
import { RealEstateDto } from './models/real-estate.model';
import { ApiResponse } from './models/api-response';

@Injectable({
  providedIn: 'root'
})
export class RealEstateService {
  private apiUrl = 'https://localhost:7224/api/realestate'; 

  constructor(private http: HttpClient) { }

  getAll(): Observable<RealEstateDto[]> {
    return this.http.get<ApiResponse<RealEstateDto[]>>(this.apiUrl).pipe(
      map((response: ApiResponse<RealEstateDto[]>) => response.response)
    );
  }

  create(realEstate: RealEstateDto): Observable<RealEstateDto> {
    return this.http.post<ApiResponse<RealEstateDto>>(this.apiUrl, realEstate).pipe(
      map((response: ApiResponse<RealEstateDto>) => response.response)
    );
  }
}
