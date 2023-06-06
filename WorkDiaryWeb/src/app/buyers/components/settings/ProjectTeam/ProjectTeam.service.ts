import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NewTeamMember } from 'src/app/buyers/models/NewTeamMember';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProjectTeamService {

  constructor(private http: HttpClient) { }

  private baseUrl = environment.API_URL;

  GetAllTeamMem(Buyer_Id: number): Observable<any> {
    const url = `${this.baseUrl}/ProjectTeam/${Buyer_Id}`;
    return this.http.get(url);
  }

  AddNewMember(NewMem: NewTeamMember): Observable<any> {
    const url = `${this.baseUrl}/ProjectTeam`;
    return this.http.post(url, NewMem);
  }

  UpdateMember(Member: NewTeamMember): Observable<any> {
    const url = `${this.baseUrl}/ProjectTeam`;
    return this.http.put(url, Member);
  }

  DeleteMember(TeamMemId: number): Observable<any> {
    const url = `${this.baseUrl}/ProjectTeam?Project_Team_Id=${TeamMemId}`;
    return this.http.delete(url);
  }

}
