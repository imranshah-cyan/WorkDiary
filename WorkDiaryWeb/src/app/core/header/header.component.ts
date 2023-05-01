import { Component, HostListener, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  isScrolled = false;
  activeSection = "";

  constructor(private renderer: Renderer2) { }

  ngOnInit() {
    window.addEventListener('scroll', this.scroll, true); // third parameter
  }

  scroll = (event: any): void => {
    if (window.pageYOffset > 0) {
      this.isScrolled = true;
    } else {
      this.isScrolled = false;
    }
  }

  @HostListener('window:scroll', [])
  onWindowScroll() {
    const scrollOffset = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop || 0;

    if (scrollOffset > 0) {
      this.isScrolled = true;
      this.renderer.addClass(document.body, 'bg-gray-100');
      this.renderer.addClass(document.querySelector('header'), 'border-b-2');
    } else {
      this.isScrolled = false;
      this.renderer.removeClass(document.body, 'bg-gray-100');
      this.renderer.removeClass(document.querySelector('header'), 'border-b-2');
    }
  }

  @HostListener('window:scroll', ['$event'])
  onScroll(event: any) {
    const sections = document.querySelectorAll('section');
    const lastSection = sections[sections.length - 1];
    const lastSectionTop = lastSection.offsetTop;
    const lastSectionHeight = lastSection.clientHeight;

    sections.forEach(section => {
      const sectionTop = section.offsetTop;
      const sectionHeight = section.clientHeight;

      if (event.target.documentElement.scrollTop >= sectionTop && event.target.documentElement.scrollTop < sectionTop + sectionHeight) {
        this.activeSection = section.id;
      }
    });

    // Check if the last section is partially visible
    if (event.target.documentElement.scrollTop >= lastSectionTop - window.innerHeight/4  && event.target.documentElement.scrollTop < lastSectionTop + lastSectionHeight) {
      this.activeSection = lastSection.id;
    }
  }


}
