using Microsoft.EntityFrameworkCore;
using ramengo.Data;
using ramengo.Models;

namespace ramengo
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            // Look for any broths already in the database.
            if (_context.Broths.Any() || _context.Proteins.Any())
            {
                return;   // Database has already been seeded.
            }

            _context.Broths.AddRange(
                new Broth
                {
                    Name = "Shio",
                    ImageInactive = "https://tech.redventures.com.br/icons/shio/inactive.svg",
                    ImageActive = "https://tech.redventures.com.br/icons/shio/active.svg",
                    Description = "Simple like the seawater, nothing more",
                    Price = 10
                },
                new Broth
                {
                    Name = "Shoyu",
                    ImageInactive = "https://tech.redventures.com.br/icons/shoyu/inactive.svg",
                    ImageActive = "https://tech.redventures.com.br/icons/shoyu/active.svg",
                    Description = "A rich soy sauce base",
                    Price = 12
                },
                new Broth
                {
                    Name = "Miso",
                    ImageInactive = "https://tech.redventures.com.br/icons/miso/inactive.svg",
                    ImageActive = "https://tech.redventures.com.br/icons/miso/active.svg",
                    Description = "Fermented soybean paste",
                    Price = 14
                }
            );

            _context.Proteins.AddRange(
                new Protein
                {
                    Name = "Chashu",
                    ImageInactive = "https://tech.redventures.com.br/icons/chashu/inactive.svg",
                    ImageActive = "https://tech.redventures.com.br/icons/chashu/active.svg",
                    Description = "A sliced flavourful pork meat with a selection of seasoned vegetables.",
                    Price = 10
                },
                new Protein
                {
                    Name = "Tofu",
                    ImageInactive = "https://tech.redventures.com.br/icons/tofu/inactive.svg",
                    ImageActive = "https://tech.redventures.com.br/icons/tofu/active.svg",
                    Description = "Soft tofu pieces",
                    Price = 8
                },
                new Protein
                {
                    Name = "Chicken",
                    ImageInactive = "https://tech.redventures.com.br/icons/chicken/inactive.svg",
                    ImageActive = "https://tech.redventures.com.br/icons/chicken/active.svg",
                    Description = "Grilled chicken breast",
                    Price = 9
                }
            );

            _context.SaveChanges();
        }
    }
}
