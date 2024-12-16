import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { RealEstateDto } from '../models/real-estate.model';
import { ApiResponse } from '../models/api-response';

@Injectable({
  providedIn: 'root'
})
export class RealEstateService {
  private apiUrl = 'https://localhost:7224/api/realestate';

  constructor(private http: HttpClient) { }

  getAll(): Observable<RealEstateDto[]> {
    return this.http.get<ApiResponse<RealEstateDto[]>>(this.apiUrl).pipe(
      map((response: ApiResponse<RealEstateDto[]>) => response.response),
      catchError(this.handleError)
    );
  }

  create(realEstate: RealEstateDto): Observable<RealEstateDto> {
    return this.http.post<ApiResponse<RealEstateDto>>(this.apiUrl, realEstate).pipe(  
      map((response: ApiResponse<RealEstateDto>) => response.response),
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse): Observable<never> {
    let errorMessages: string[] = [];

    if (error.error instanceof ErrorEvent) {
      errorMessages.push(`An error occurred: ${error.error.message}`);
    } else {
      if (error.error && error.error.errors) {
        errorMessages = error.error.errors;
      } else {
        errorMessages.push(`Server returned code: ${error.status}, error message is: ${error.message}`);
      }
    }

    console.error('Error(s):', errorMessages);
    return throwError(() => new Error(errorMessages.join(', ')));
  }
}
