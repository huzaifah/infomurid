import { Component, Injector, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MenuItem } from '@shared/layout/menu-item';

@Component({
    templateUrl: './sidebar-nav.component.html',
    selector: 'sidebar-nav',
    encapsulation: ViewEncapsulation.None
})
export class SideBarNavComponent extends AppComponentBase {

    menuItems: MenuItem[] = [
        new MenuItem(this.l('HomePage'), '', 'home', '/app/home'),

        // new MenuItem(this.l('Tenants'), 'Pages.Tenants', 'business', '/app/tenants'),
        new MenuItem(this.l('Users'), 'Pages.Users', 'people', '/app/users'),
        // new MenuItem(this.l('Roles'), 'Pages.Roles', 'local_offer', '/app/roles'),
        // new MenuItem(this.l('About'), '', 'info', '/app/about'),

        new MenuItem('Pentadbiran Sistem', '', 'menu', ''),
        new MenuItem('Maklumat Sekolah', '', 'menu', '', [
            new MenuItem('Asas', '', 'menu', '', [
                new MenuItem('Tahun Akademik', '', '', '/app/tahunakademik'),
                new MenuItem('Kelas', '', '', '/app/kelas'),
                new MenuItem('Tahap', '', '', '/app/levellabel'),
                new MenuItem('Subjek', '', '', '/app/underconstruction'),
                new MenuItem('Guru', '', '', '/app/underconstruction'),
                new MenuItem('Guru Matapelajaran', '', '', '/app/underconstruction'),
                new MenuItem('Logo', '', '', '/app/underconstruction')
            ]),
            new MenuItem('Penilaian', '', 'menu', '', [
                new MenuItem('Senarai Peperiksaan', '', '', '/app/underconstruction'),
                new MenuItem('Gred', '', '', '/app/underconstruction'),
                new MenuItem('Piawai', '', '', '/app/underconstruction'),
                new MenuItem('Merit', '', '', '/app/underconstruction'),
                new MenuItem('PNG Menengah Rendah', '', '', '/app/underconstruction'),
                new MenuItem('PNG Menengah Atas', '', '', '/app/underconstruction'),
                new MenuItem('Sumbangan Sistem Rumah', '', '', '/app/underconstruction')
            ]),
            new MenuItem('Disiplin/Sahsiah', '', 'menu', '', [
                new MenuItem('Salah Laku', '', '', '/app/underconstruction'),
                new MenuItem('Tindakan', '', '', '/app/underconstruction'),
                new MenuItem('Kemaskini Disiplin', '', '', '/app/underconstruction'),
                new MenuItem('Khidmat Bakti/Special Talent', '', '', '/app/underconstruction')
            ]),
            new MenuItem('Kokurikulum', '', 'menu', '', [
                new MenuItem('Rumah Sukan', '', '', '/app/underconstruction'),
                new MenuItem('Persatuan/Kelab', '', '', '/app/underconstruction'),
                new MenuItem('Badan beruniform', '', '', '/app/underconstruction'),
                new MenuItem('Sukan dan Permainan', '', '', '/app/underconstruction'),
                new MenuItem('Jawatan yang disandang', '', '', '/app/underconstruction'),
                new MenuItem('Peringkat penglibatan', '', '', '/app/underconstruction'),
                new MenuItem('Pencapaian', '', '', '/app/underconstruction'),
                new MenuItem('Skor pencapaian', '', '', '/app/underconstruction'),
                new MenuItem('Skor pencapaian sistem rumah', '', '', '/app/underconstruction'),
                new MenuItem('Gred pencapaian kokurikulum', '', '', '/app/underconstruction'),
                new MenuItem('Senarai acara', '', '', '/app/underconstruction'),
            ]),
            new MenuItem('Asrama', '', 'menu', '', [
                new MenuItem('Kamar', '', '', '/app/underconstruction'),
                new MenuItem('Warden', '', '', '/app/underconstruction')
            ]),
            new MenuItem('3K', '', 'menu', '', [
                new MenuItem('Pencapaian (3K)', '', '', '/app/underconstruction')
            ]),
        ]),

        new MenuItem('Maklumat Pelajar', '', 'menu', ''),
        new MenuItem('Akademik', '', 'menu', ''),
        new MenuItem('Kokurikulum', '', 'menu', ''),
        new MenuItem('Laporan', '', 'menu', ''),
        new MenuItem('Disiplin', '', 'menu', ''),
        new MenuItem('Asrama', '', 'menu', ''),
        new MenuItem('Markah Rumah', '', 'menu', ''),
        new MenuItem('Projek Terancang', '', 'menu', ''),
        new MenuItem('Maklumat Pelajar', '', 'menu', ''),
        new MenuItem('Analisis Item', '', 'menu', ''),
        new MenuItem('Cari', '', 'menu', ''),
        new MenuItem('3K', '', 'menu', '')

        // new MenuItem(this.l('MultiLevelMenu'), '', 'menu', '', [
        //     new MenuItem('ASP.NET Boilerplate', '', '', '', [
        //         new MenuItem('Home', '', '', 'https://aspnetboilerplate.com/?ref=abptmpl'),
        //         new MenuItem('Templates', '', '', 'https://aspnetboilerplate.com/Templates?ref=abptmpl'),
        //         new MenuItem('Samples', '', '', 'https://aspnetboilerplate.com/Samples?ref=abptmpl'),
        //         new MenuItem('Documents', '', '', 'https://aspnetboilerplate.com/Pages/Documents?ref=abptmpl')
        //     ]),
        //     new MenuItem('ASP.NET Zero', '', '', '', [
        //         new MenuItem('Home', '', '', 'https://aspnetzero.com?ref=abptmpl'),
        //         new MenuItem('Description', '', '', 'https://aspnetzero.com/?ref=abptmpl#description'),
        //         new MenuItem('Features', '', '', 'https://aspnetzero.com/?ref=abptmpl#features'),
        //         new MenuItem('Pricing', '', '', 'https://aspnetzero.com/?ref=abptmpl#pricing'),
        //         new MenuItem('Faq', '', '', 'https://aspnetzero.com/Faq?ref=abptmpl'),
        //         new MenuItem('Documents', '', '', 'https://aspnetzero.com/Documents?ref=abptmpl')
        //     ])
        // ])
    ];

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    showMenuItem(menuItem): boolean {
        if (menuItem.permissionName) {
            return this.permission.isGranted(menuItem.permissionName);
        }

        return true;
    }
}
