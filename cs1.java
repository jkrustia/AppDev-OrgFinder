import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.HashMap;

public class cs1 {

    // HashMap to store organization data entered by the user
    private static HashMap<String, String> organizationData = new HashMap<>();
    
    // Components for GUI
    private static JTextField inputTextField;
    private static JTextField courseTextField; 
    private static JComboBox<String> interestComboBox; 
    private static JComboBox<String> passionComboBox; 

    // Sample organizations with their interests and passions
    private static HashMap<String, String> sampleOrganizations = new HashMap<>();
    static {
        // Initialize sample organizations
        sampleOrganizations.put("PUP Association of Students for Computer Intelligence Integration (ASCII)", "Technology|Coding/Programming");
        sampleOrganizations.put("AWS Cloud Club - PUP Manila", "Technology|Coding/Programming");
        sampleOrganizations.put("PUP Harana String Co.", "Music|Playing Instruments");
        sampleOrganizations.put("PUP Polysound Band", "Music|Playing Instruments");
        sampleOrganizations.put("Pylon Esports", "Sports|Athletic Performance");
        sampleOrganizations.put("PUP Sintang Pusa", "Sports|Athletic Performance");
        sampleOrganizations.put("PUP Buklod Sining", "Arts and Creativity|Artistic Expression");
        sampleOrganizations.put("PUP Maharlika Dance Artists", "Arts and Creativity|Artistic Expression");
        sampleOrganizations.put("DZMC - Young Communicators' Guild", "Cultural and Language|Global Culture Collective");
        sampleOrganizations.put("Sinagbayan PUP", "Cultural and Language|Global Culture Collective");
        sampleOrganizations.put("SAMASA PUP", "Community Service and Activism|Social Justice and Advocacy");
        sampleOrganizations.put("BAHAGHARI PUP", "Community Service and Activism|Social Justice and Advocacy");
        sampleOrganizations.put("PUPBC Young Educators' Society", "Academic and Career-related|Career Catalysts");
        sampleOrganizations.put("Future Business Teachers' Organization", "Academic and Career-related|Career Catalysts");
        sampleOrganizations.put("PUP Electronics Engineering Students' Society", "Recreation and Hobbies|Leisure Pursuits");
        sampleOrganizations.put("PUP BiblioFlix", "Recreation and Hobbies|Leisure Pursuits");
    }

    public static void main(String[] args) {
        
        // Set up the JFrame
        JFrame frame = new JFrame("Organization Finder System");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setResizable(true);

        // Main panel to hold all UI components
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.Y_AXIS));
        mainPanel.setBorder(BorderFactory.createEmptyBorder(20, 20, 20, 20));

        // Panel 1 - Welcome Message
        JPanel panel1 = new JPanel();
        JLabel wlcLabel = new JLabel("Welcome to OrgFinder System");
        wlcLabel.setFont(wlcLabel.getFont().deriveFont(20.0f));
        panel1.add(wlcLabel);
        mainPanel.add(panel1);

        // Panel 2 - Name Input
        JPanel panel2 = new JPanel();
        JLabel nameLabel = new JLabel("Name: ");
        inputTextField = new JTextField(15);
        panel2.add(nameLabel);
        panel2.add(inputTextField);
        mainPanel.add(panel2);

        // Panel 3 - Course Input
        JPanel panel3 = new JPanel();
        JLabel courLabel = new JLabel("Course: ");
        courseTextField = new JTextField(15);
        panel3.add(courLabel);
        panel3.add(courseTextField);
        mainPanel.add(panel3);

        // Panel 4 - Interest drop box
        JPanel panel4 = new JPanel();
        panel4.add(new JLabel("Interest"));
        interestComboBox = new JComboBox<>(new String[]{"Select Here", "Technology", "Music", "Sports", "Arts and Creativity", "Academic and Career-related", "Cultural and Language", "Community Service and Activism", "Recreation and Hobbies"});
        panel4.add(interestComboBox);
        mainPanel.add(panel4);

        // Panel 5 - Passion drop box
        JPanel panel5 = new JPanel();
        panel5.add(new JLabel("Passion"));
        passionComboBox = new JComboBox<>(new String[]{"Select Here", "Coding/Programming", "Playing Instruments", "Athletic Performance", "Artistic Expression", "Career Catalysts", "Global Culture Collective", "Social Justice and Advocacy", "Leisure Pursuits"});
        panel5.add(passionComboBox);
        mainPanel.add(panel5);

        // Clear Button
        JButton clearButton = new JButton("Clear");
        clearButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                 // Clear the input fields and combo boxes
                inputTextField.setText("");
                courseTextField.setText("");
                interestComboBox.setSelectedIndex(0);
                passionComboBox.setSelectedIndex(0);
            }
        });
        mainPanel.add(clearButton);

        // Generate Button
        JButton generateButton = new JButton("Generate");
        generateButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String name = inputTextField.getText();
                String interest = (String) interestComboBox.getSelectedItem();
                String passion = (String) passionComboBox.getSelectedItem();

                // Find matching organizations based on interest and passion
                ArrayList<String> matches = findMatchingOrganizations(interest, passion);
                if (!matches.isEmpty()) {
                    // Store organization data for the user
                    organizationData.put(name, "Interest: " + interest + ", Passion: " + passion);
                    StringBuilder message = new StringBuilder("Organization generated successfully!\nRecommended Organizations:\n");
                    for (String match : matches) {
                        message.append("- ").append(match).append("\n");
                    }
                    JOptionPane.showMessageDialog(frame, message.toString());
                } else {
                    JOptionPane.showMessageDialog(frame, "No organizations found for the selected interest and passion.");
                }
            }
        });
        mainPanel.add(generateButton);

        // Exit Button
        JButton exitButton = new JButton("Exit");
        exitButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                System.exit(0);
            }
        });
        mainPanel.add(exitButton);

        // Add the main panel to the frame
        frame.add(mainPanel);
        frame.pack();
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
    }

    // Method to find matching organizations based on interest and passion
    private static ArrayList<String> findMatchingOrganizations(String interest, String passion) {
        ArrayList<String> matches = new ArrayList<>();
        for (String organization : sampleOrganizations.keySet()) {
            String[] interestsAndPassions = sampleOrganizations.get(organization).split("\\|");
            String orgInterest = interestsAndPassions[0];
            String orgPassion = interestsAndPassions[1];
            // Check if the organization matches the interest or passion
            if (orgInterest.equals(interest) || orgPassion.equals(passion)) {
                matches.add(organization);
            }
        }
        return matches;
    }
}