export interface ApiResponse<T> {
  isSucceeded: boolean;
  response: T;
  errors: string[];
}
