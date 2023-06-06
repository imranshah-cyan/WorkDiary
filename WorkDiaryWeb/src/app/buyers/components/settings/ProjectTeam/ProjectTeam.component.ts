import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ProjectTeamService } from './ProjectTeam.service';
import { CacheStorageService } from 'src/app/Shared/services/CacheStorage.service';
import { ProjectTeam } from 'src/app/buyers/models/ProjectTeam';
import { JobsService } from 'src/app/buyers/services/jobs.service';
import { Job } from 'src/app/buyers/models/Job';
import { NewTeamMember } from 'src/app/buyers/models/NewTeamMember';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-ProjectTeam',
  templateUrl: './ProjectTeam.component.html',
  styleUrls: ['./ProjectTeam.component.css']
})
export class ProjectTeamComponent implements OnInit {

  selectedItemId: number = 0;
  showConfirmDeleteContainer = false;

  NewMemberAdded: string = "";
  MemberDeleted:boolean = false;
  MemberUpdated:boolean = false;

  CurrentUserId: number = 0;

  itemsPerPage = 10;
  currentPage = 1;

  ProjectTeamMem: ProjectTeam[] = [];
  Jobs: Job[] = [];

  constructor(private toastr: ToastrService,
    private cacheStorage: CacheStorageService,
    private projectTeam: ProjectTeamService,
    private job: JobsService) {

    const userId = this.cacheStorage.get('User').USER_ID;
    this.CurrentUserId = userId;
    this.TotalTeamMembers(this.CurrentUserId);
    this.getJobsByBuyerId(this.CurrentUserId);

  }

  TotalTeamMembers(Buyer_Id: number) {
    this.projectTeam.GetAllTeamMem(Buyer_Id).subscribe(
      (response: ProjectTeam[]) => {
        // console.log(response);
        this.ProjectTeamMem = response;
      },
      (error: any) => {
        // console.log(error);
      }
    );
  }

  getJobsByBuyerId(Buyer_Id:number) {
    this.job.getJobs(this.CurrentUserId).subscribe(
      (response: Job[]) => {
        // console.log(response);
        this.Jobs = response;
      },
      (error: any) => {
        // console.log(error);
      }
    );
  }

  AddProjectTeamMem(item: NgForm) {

    const newTeamMember: NewTeamMember = {
      Project_Team_Id: 0,
      Job_Id: item.form.value.job, // Update this value based on the selected job ID
      Designation_Id: 1, // Update this value based on the selected designation ID
      Name: item.form.value.Name,
      Email: item.form.value.email
    };

    this.projectTeam.AddNewMember(newTeamMember).subscribe(
      (response: any) => {
        // console.log(response);
        this.NewMemberAdded = 'success';
        this.TotalTeamMembers(this.CurrentUserId);
      },
      (error: any) => {

      }
    )
  }

  get totalPages(): number {
    return Math.ceil(this.ProjectTeamMem.length / this.itemsPerPage);
  }

  get paginatedData(): any[] {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    return this.ProjectTeamMem.slice(startIndex, endIndex);
  }

  previousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }

  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
    }
  }

  editItem(item: any): void {
    item.editing = true;
  }

  saveItem(item: any): void {
    item.editing = false;

    const UpdateTeamMember: NewTeamMember = {
      Project_Team_Id: item.PROJECT_TEAM_ID,
      Job_Id: item.JOB_ID,
      Designation_Id: 1,
      Name: item.NAME,
      Email: item.EMAIL
    };

    this.projectTeam.UpdateMember(UpdateTeamMember).subscribe(
      (response: any) => {
        // console.log(response);
        this.MemberUpdated = true;
        this.TotalTeamMembers(this.CurrentUserId);
      },
      (error: any) => {

      }
    )
  }

  cancelEdit(item: any): void {
    item.editing = false;
    // Implement the cancel edit functionality here
    console.log('Cancel edit item:', item);
  }

  showConfirmDelete(item: ProjectTeam) {
    this.selectedItemId = item.PROJECT_TEAM_ID;
    this.showConfirmDeleteContainer = true;
  }


  cancelDelete() {
    // Set the showCancelDeleteContainer flag to false to hide the cancel delete container
    this.showConfirmDeleteContainer = false;
  }

  confirmDelete(): void {
    // Implement the delete functionality here
    // console.log('Delete item:', this.selectedItemId);

    this.projectTeam.DeleteMember(this.selectedItemId).subscribe(
      (response) => {
        console.log(response);
        this.MemberDeleted = true;
        this.showConfirmDeleteContainer = false;
        this.TotalTeamMembers(this.CurrentUserId);
        // this.ProjectTeamMem = response;
      },
      (error: any) => {
        // console.log(error);
      }
    );
  }


  ngOnInit() {
  }

}
