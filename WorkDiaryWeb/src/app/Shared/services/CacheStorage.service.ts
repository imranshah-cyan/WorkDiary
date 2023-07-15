import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CacheStorageService {

constructor() { }

  set(key: string, value: any): void {
    localStorage.setItem(key, JSON.stringify(value));
  }

  get(key: string): any {
    const value = localStorage.getItem(key);
    return value ? JSON.parse(value) : null;
  }

  remove(key: string): void {
    localStorage.removeItem(key);
  }

  clear(): void {
    localStorage.clear();
    sessionStorage.clear();
  }

}
